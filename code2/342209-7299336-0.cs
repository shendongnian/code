        public static string RemoveNonMTChars(string str)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'M' && str[i] == 'T')
                {
                    sb.Append(str[i]);
                }
            }
            return sb.ToString();
        }
