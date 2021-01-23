    static string extract(string original)
            {
                List<char> characters = new List<char>();
                string unique = string.Empty;
    
                foreach (char letter in original.ToCharArray())
                {
                    if (!characters.Contains(letter))
                    {
                        characters.Add(letter);
                    }
                }
    
                foreach (char letter in characters)
                {
                    unique += letter;
                }
    
                return unique;
    }
