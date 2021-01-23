    using (StreamReader sr = new StreamReader(path)) 
    {
         string line = string.Empty;
         while (sr.Peek() >= 0) 
         {
              char c = (char)sr.Read();
              if (c == '\n')
              {
                  //end of line encountered
                  Console.WriteLine(line);
                  //create new line
                  line = string.Empty;
              }
              else
              {
                   line += (char)sr.Read();
              }
         }
    }
