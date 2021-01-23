             while ((line = stringReader.ReadLine()) != null)
             {
                 // split the lines
                 for (int c = 0; c < line.Length; c++)
                 {
                     line = line.Replace("\\", "");
                     lineBreakOne = line.Substring(1, c - 2);
                     lineBreakTwo = line.Substring(c + 2, line.Length - 2);
                 }
             }
