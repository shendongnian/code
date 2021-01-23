        public static String RemoveLineEndings(this String text)
        {
            StringBuilder newText = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (!char.IsControl(text, i))
                    newText.Append(text[i]);
            }
            return newText.ToString();
        }
