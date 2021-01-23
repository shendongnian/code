     public static string ReadToChar(this StreamReader sr, char splitCharacter)
        {        
            char nextChar;
            StringBuilder line = new StringBuilder();
            while (sr.Peek() > 0)
            {               
                nextChar = (char)sr.Read();
                if (nextChar == splitCharacter) return line.ToString();
                line.Append(nextChar);
            }
    
            return line.Length == 0 ? null : line.ToString();
        }
