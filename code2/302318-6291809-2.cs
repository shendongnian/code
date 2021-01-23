  1  using System;
  2  using System.IO;
  3  using iTextSharp.text.pdf;
  4  
  5  namespace PdfToText
  6  {
  7      /// <summary>
  8      /// Parses a PDF file and extracts the text from it.
  9      /// </summary>
 10      public class PDFParser 
 11      {
 12          /// BT = Beginning of a text object operator 
 13          /// ET = End of a text object operator
 14          /// Td move to the start of next line
 15          ///  5 Ts = superscript
 16          /// -5 Ts = subscript
 17  
 18          #region Fields
 19  
 20          #region _numberOfCharsToKeep
 21          /// <summary>
 22          /// The number of characters to keep, when extracting text.
 23          /// </summary>
 24          private static int _numberOfCharsToKeep = 15;
 25          #endregion
 26  
 27          #endregion
 28  
 29          #region ExtractText
 30          /// <summary>
 31          /// Extracts a text from a PDF file.
 32          /// </summary>
 33          /// <param name="inFileName">the full path to the pdf file.</param>
 34          /// <param name="outFileName">the output file name.</param>
 35          /// <returns>the extracted text</returns>
 36          public bool ExtractText(string inFileName, string outFileName)
 37          {
 38              StreamWriter outFile = null;
 39              try
 40              {
 41                  // Create a reader for the given PDF file
 42                  PdfReader reader = new PdfReader(inFileName);
 43                  //outFile = File.CreateText(outFileName);
 44                  outFile = new StreamWriter(outFileName, false, System.Text.Encoding.UTF8);
 45                  
 46                  Console.Write("Processing: ");
 47                  
 48                  int     totalLen    = 68;
 49                  float   charUnit    = ((float)totalLen) / (float)reader.NumberOfPages;
 50                  int     totalWritten= 0;
 51                  float   curUnit     = 0;
 52  
 53                  for (int page = 1; page <= reader.NumberOfPages; page++)
 54                  {                    
 55                      outFile.Write(ExtractTextFromPDFBytes(reader.GetPageContent(page)) + " ");
 56                      
 57                      // Write the progress.
 58                      if (charUnit >= 1.0f)
 59                      {
 60                          for (int i = 0; i < (int)charUnit; i++)
 61                          {
 62                              Console.Write("#");
 63                              totalWritten++;
 64                          }
 65                      }
 66                      else
 67                      {
 68                          curUnit += charUnit;
 69                          if (curUnit >= 1.0f)
 70                          {
 71                              for (int i = 0; i < (int)curUnit; i++)
 72                              {
 73                                  Console.Write("#");
 74                                  totalWritten++;
 75                              }
 76                              curUnit = 0;
 77                          }
 78                          
 79                      }
 80                  }
 81  
 82                  if (totalWritten < totalLen)
 83                  {
 84                      for (int i = 0; i < (totalLen - totalWritten); i++)
 85                      {
 86                          Console.Write("#");
 87                      }
 88                  }
 89                  return true;
 90              }
 91              catch
 92              {
 93                  return false;
 94              }
 95              finally
 96              {
 97                  if (outFile != null) outFile.Close();
 98              }
 99          }
100          #endregion
101  
102          #region ExtractTextFromPDFBytes
103          /// <summary>
104          /// This method processes an uncompressed Adobe (text) object 
105          /// and extracts text.
106          /// </summary>
107          /// <param name="input">uncompressed</param>
108          /// <returns></returns>
109          private string ExtractTextFromPDFBytes(byte[] input)
110          {
111              if (input == null || input.Length == 0) return "";
112  
113              try
114              {
115                  string resultString = "";
116  
117                  // Flag showing if we are we currently inside a text object
118                  bool inTextObject = false;
119  
120                  // Flag showing if the next character is literal 
121                  // e.g. '\\' to get a '\' character or '\(' to get '('
122                  bool nextLiteral = false;
123  
124                  // () Bracket nesting level. Text appears inside ()
125                  int bracketDepth = 0;
126  
127                  // Keep previous chars to get extract numbers etc.:
128                  char[] previousCharacters = new char[_numberOfCharsToKeep];
129                  for (int j = 0; j < _numberOfCharsToKeep; j++) previousCharacters[j] = ' ';
130  
131  
132                  for (int i = 0; i < input.Length; i++)
133                  {
134                      char c = (char)input[i];
135  
136                      if (inTextObject)
137                      {
138                          // Position the text
139                          if (bracketDepth == 0)
140                          {
141                              if (CheckToken(new string[] { "TD", "Td" }, previousCharacters))
142                              {
143                                  resultString += "\n\r";
144                              }
145                              else
146                              {
147                                  if (CheckToken(new string[] {"'", "T*", "\""}, previousCharacters))
148                                  {
149                                      resultString += "\n";
150                                  }
151                                  else
152                                  {
153                                      if (CheckToken(new string[] { "Tj" }, previousCharacters))
154                                      {
155                                          resultString += " ";
156                                      }
157                                  }
158                              }
159                          }
160  
161                          // End of a text object, also go to a new line.
162                          if (bracketDepth == 0 && 
163                              CheckToken( new string[]{"ET"}, previousCharacters))
164                          {
165  
166                              inTextObject = false;
167                              resultString += " ";
168                          }
169                          else
170                          {
171                              // Start outputting text
172                              if ((c == '(') && (bracketDepth == 0) && (!nextLiteral))
173                              {
174                                  bracketDepth = 1;
175                              }
176                              else
177                              {
178                                  // Stop outputting text
179                                  if ((c == ')') && (bracketDepth == 1) && (!nextLiteral))
180                                  {
181                                      bracketDepth = 0;
182                                  }
183                                  else
184                                  {
185                                      // Just a normal text character:
186                                      if (bracketDepth == 1)
187                                      {
188                                          // Only print out next character no matter what. 
189                                          // Do not interpret.
190                                          if (c == '\\' && !nextLiteral)
191                                          {
192                                              nextLiteral = true;
193                                          }
194                                          else
195                                          {
196                                              if (((c >= ' ') && (c <= '~')) ||
197                                                  ((c >= 128) && (c < 255)))
198                                              {
199                                                  resultString += c.ToString();
200                                              }
201  
202                                              nextLiteral = false;
203                                          }
204                                      }
205                                  }
206                              }
207                          }
208                      }
209  
210                      // Store the recent characters for 
211                      // when we have to go back for a checking
212                      for (int j = 0; j < _numberOfCharsToKeep - 1; j++)
213                      {
214                          previousCharacters[j] = previousCharacters[j + 1];
215                      }
216                      previousCharacters[_numberOfCharsToKeep - 1] = c;
217  
218                      // Start of a text object
219                      if (!inTextObject && CheckToken(new string[]{"BT"}, previousCharacters))
220                      {
221                          inTextObject = true;
222                      }
223                  }
224                  return resultString;
225              }
226              catch
227              {
228                  return "";
229              }
230          }
231          #endregion
232  
233          #region CheckToken
234          /// <summary>
235          /// Check if a certain 2 character token just came along (e.g. BT)
236          /// </summary>
237          /// <param name="search">the searched token</param>
238          /// <param name="recent">the recent character array</param>
239          /// <returns></returns>
240          private bool CheckToken(string[] tokens, char[] recent)
241          {
242              foreach(string token in tokens)
243              {
244                  if ((recent[_numberOfCharsToKeep - 3] == token[0]) &&
245                      (recent[_numberOfCharsToKeep - 2] == token[1]) &&
246                      ((recent[_numberOfCharsToKeep - 1] == ' ') ||
247                      (recent[_numberOfCharsToKeep - 1] == 0x0d) ||
248                      (recent[_numberOfCharsToKeep - 1] == 0x0a)) &&
249                      ((recent[_numberOfCharsToKeep - 4] == ' ') ||
250                      (recent[_numberOfCharsToKeep - 4] == 0x0d) ||
251                      (recent[_numberOfCharsToKeep - 4] == 0x0a))
252                      )
253                  {
254                      return true;
255                  }
256              }
257              return false;
258          }
259          #endregion
260      }
261  }
