        public static int GetValue(string text, string keyword)
        {
            var find = text.Substring(text.IndexOf(keyword) + keyword.Length);
            string _tempValue = string.Empty;
            for (int x = 0; x < find.Length; x++)
            {
                if (!char.IsDigit(find[x]) && x > 0)
                    break;
                _tempValue += find[x];
            }
            if (int.TryParse(_tempValue.Trim(), out int number))
            {
                return number;
            }
            else
            {
                return 0;
            }
        }
