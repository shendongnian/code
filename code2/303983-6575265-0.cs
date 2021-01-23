        public static string EncodeHtml(string text)
        {
            if (text == null) return string.Empty;
            StringBuilder decodedText = new StringBuilder();
            foreach (char value in text)
            {
                int i = (int)value;
                if (i > 127)
                {
                    decodedText.Append(string.Format("&#{0};", i));
                }
                else
                {
                    decodedText.Append(value);
                }
            }
            return decodedText.ToString();
        }
