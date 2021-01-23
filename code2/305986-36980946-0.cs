        public static string RemoveCharFromString(string input, char charItem)
        {
            int indexOfChar = input.IndexOf(charItem);
            if (indexOfChar >= 0)
            {
                input = input.Remove(indexOfChar, 1);
            }
            return input;
        }
