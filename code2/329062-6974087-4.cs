     static string noDups(string word)
            {
                string table = "";
                int pos = 0;
                foreach (var character in word.ToCharArray())
                {
                    pos = table.IndexOf(character, Math.Abs(pos));
                    if (pos == -1)
                    {
                        table += character;
                    }
             
                    
                } 
                return table;
    
            }
