        public static string RemoveNonAlphanumeric(string text)
        {
            StringBuilder sb = new StringBuilder(text.Length);
            for (int i = 0; i < text.Length; i++)
            {
                char c = Char.ToLower(text[i]);
                if (c >= 'a' && c <= 'z' ||  c >= '0' && c <= '9')
                    sb.Append(text[i]);
            }
            return sb.ToString();
        }
