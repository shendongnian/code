         List<string> lines = new List<string>();
         using (var sr = new StreamReader("file.txt"))
         {
              while (sr.Peek() >= 0)
                  lines.Add(sr.ReadLine());
         }
