         using (var sr = new StreamReader("file.txt"))
         {
              string line;
              while (line = sr.ReadLine() != null) 
              {
                  // process the file line by line
              }
         }
