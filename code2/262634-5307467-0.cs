        static public string TrimAndLower(string str)
        {
            
            if (str == null)
            {
                return null;
            }
            int i = 0;
            int j = str.Length - 1;
            StringBuilder sb;
            while (i < str.Length)
            {
                if (Char.IsWhiteSpace(str[i])) // or say "if (str[i] == ' ')" if you only care about spaces
                {
                    i++;
                }
                else
                {
                    break;
                }
            }
            while (j > i)
            {
                if (Char.IsWhiteSpace(str[j])) // or say "if (str[j] == ' ')" if you only care about spaces
                {
                    j--;
                }
                else
                {
                    break;
                }
            }
            if (i > j)
            {
                return "";
            }
            sb = new StringBuilder(j - i + 1);
            
            while (i <= j)
            {
                if (Char.IsUpper(str[i]))
                {
                    sb.Append(Char.ToLower(str[i]));
                }
                else
                {
                    sb.Append(str[i]);
                }
                i++;
            }
            return sb.ToString();
        }
