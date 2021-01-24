    public IEnumerable<TextReader> ReadSeparatedFile(string filePath)
    {
         using (var rdr = new StreamReader(filePath))
         {
              string line = rdr.ReadLine();
              while(line is object)
              {
                  var buffer = new StringBuilder();
                  do
                  {
                      if (line != string.Empty) buffer.AppendLine(line);
                      line = rdr.ReadLine();
                  } while (line is object && line != string.Empty())
                  yield return new StringReader(buffer.ToString());
              }
         }
    }
