    public IEnumerable<TextReader> ReadSeparatedFile(string filePath)
    {
         using (var rdr = new StreamReader(filePath))
         {
              string line = "";
              string header = rdr.ReadLine();
              while(line is object)
              {
                  var buffer = new StringBuilder(header);
                  while (line is object && line != string.Empty())
                  {
                      if (line != string.Empty) buffer.AppendLine(line);
                      line = rdr.ReadLine();
                  }
                  yield return new StringReader(buffer.ToString());
              }
         }
    }
