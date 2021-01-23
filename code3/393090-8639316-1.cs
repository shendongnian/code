        static string ReadString(FileStream fs)
        {
            var reader = new StreamReader(fs);
            var sb = new StringBuilder();
            bool inString = false;
            while (reader.Peek() >= 0)
            {
                char ch = (char)reader.Read();
                if (ch == '"')
                {
                    if (inString)
                        break;
                    inString = true;
                    continue;
                }
                sb.Append(ch);
            }
            return sb.ToString();
        }
  
