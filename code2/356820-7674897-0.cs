            string s = "|test1|This is a string|test2|this is a string";
            string[] tokens = s.Split(new char[] { '|' });
            string x = "";
            for (int i = 0; i < tokens.Length; i++)
            {
                if (i % 2 == 0 && tokens[i].Length > 0)
                {
                    x += "\n" + tokens[i] + "\n";
                    
                }
                else if(tokens[i].Length > 0)
                {
                    x += "|" + tokens[i] + "|";
                }
            }
