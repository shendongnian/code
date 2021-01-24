    public IEnumerable<TextReader> ReadSeparatedFile(string filePath)
    {
         using (var rdr = new StreamReader(filePath))
         {
              string line = "";
              while(line is object)
              {
                  var buffer = new StringBuilder();
                  while (line is object && line != string.Empty())
                  {
                      if (line != string.Empty) buffer.AppendLine(line);
                      line = rdr.ReadLine();
                  }
                  yield return new StringReader(buffer.ToString());
              }
         }
    }
