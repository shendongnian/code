        public static string ReverseWordsMultiple(string originalString)
        {
            String[] sentences = originalString.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder builder = new StringBuilder();
            foreach (String senctence in sentences)
            {
                builder.Append(string.Join(" ", senctence.Split(' ').Where(x => !string.IsNullOrEmpty(x)).Reverse()));
                builder.Append(". ");
            }
            return builder.ToString().TrimEnd();
        }
