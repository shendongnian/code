        private static string GetLabel(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "00:00:00";
            var builder = new StringBuilder();
            var arr = text.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            var i = 0;
            foreach (var t in arr)
            {
                builder.Append(t.Length == 1 ? "0" + t : t);
                if (arr.Length - 1 != i++)
                    builder.Append(":");
            }
            return builder.ToString();
        }
