        public static string RemoveNonAlphanumeric(string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);
            for (int i = 0; i < text.Length; i++)
            {
                char c = Char.ToLower(text[i]);
                if (c >= 'a' && c <= 'z' || Char.IsDigit(c) )
                    sb.Append(text[i]);
            }
            return sb.ToString();
        }
