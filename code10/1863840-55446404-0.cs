    class Program
    {
        static void Main(string[] args)
        {
            var emailBody = GetEmail();
            using (var reader = new StringReader(emailBody))
            {
                var lines = new List<string>();
                const int startingRow = 2; // Starting line to read from (start at Marketing ID line)
                const int sectionItems = 4; // Header row (ex. Marketing ID & Local Number Line) + Dash Row + Value Row + New Line
                // Add all lines to a list
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line.Trim()); // Add each line to the list and remove any leading or trailing spaces
                }
                for (var i = startingRow; i < lines.Count; i += sectionItems)
                {
                    var currentLine = lines[i];
                    var indexToBeginSeparatingColumns = currentLine.IndexOf("  "); // The first time we see double spaces, we will use as the column delimiter, not the best solution but should work
                    
                    var header1 = currentLine.Substring(0, indexToBeginSeparatingColumns);
                    var header2 = currentLine.Substring(indexToBeginSeparatingColumns, currentLine.Length - indexToBeginSeparatingColumns).Trim();
                    currentLine = lines[i+2]; //Skip dash line
                    indexToBeginSeparatingColumns = currentLine.IndexOf("  ");
                    string value1 = "", value2 = "";
                    if (indexToBeginSeparatingColumns == -1) // Use case of there being no value in the 2nd column, could be better
                    {
                        value1 = currentLine.Trim();
                    }
                    else
                    {
                        value1 = currentLine.Substring(0, indexToBeginSeparatingColumns);
                        value2 = currentLine.Substring(indexToBeginSeparatingColumns, currentLine.Length - indexToBeginSeparatingColumns).Trim();
                    }                    
                    Console.WriteLine(string.Format("{0},{1},{2},{3}", header1, value1, header2, value2));
                }
            }
        }
        static string GetEmail()
        {
            return @"EMAIL STARTING IN APRIL
                    Marketing ID                                     Local Number
                    -------------------                              ----------------------
                    GR332230                                         0000232323
                    Dispatch Code                                    Logic code
                    -----------------                                -------------------
                    GX3472                                           1
                    Destination ID                                   Destination details
                    -----------------                                -------------------
                    3411144";
        }
    }
