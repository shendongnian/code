    int newLineIndex = 0;
    newline[0] = (string) line[0].Clone();
    for (int i = 1; i < line.Length; i++)
    {
           if (line[i] == null) continue;
           foreach (string item in Cmpstr)
           {
                  if (line[i].Contains(item))
                  {
                         newLineIndex++;
                         newline[newLineIndex] += " " + line[i];
                   }
                   else
                   {
                         newline[newLineIndex] += " " + line[i];
                   }
           }
    }
