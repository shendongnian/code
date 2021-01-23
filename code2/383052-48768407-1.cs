    public static class StringExtensions
    {
        public static string MaskField(this string str, string field, string mask = "***")
        {
            var separators = ",;";
            var sb = new StringBuilder();
            foreach (var keyValue in Regex.Split(str, $"(?<=[{separators}])"))
            {
                var temp = keyValue;
                var index = keyValue.IndexOf("=");
                if (index > 0)
                {
                    var key = keyValue.Substring(0, index);
                    if (string.Compare(key.Trim(), field.Trim(), true) == 0)
                    {
                        var end = separators.Contains(keyValue.Last()) ? keyValue.Last().ToString() : "";
                        temp = key + "=" + mask + end;
                    }
                }
                sb.Append(temp);
            }
            return sb.ToString();
        }
    }
