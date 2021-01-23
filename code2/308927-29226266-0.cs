    public string GetCorrectString(string IncorrectString)
        {
            string[] strarray = IncorrectString.Split(' ');
            var sb = new StringBuilder();
            foreach (var str in strarray)
            {
                if (str != string.Empty)
                {
                    sb.Append(str).Append(' ');
                }
            }
            return sb.ToString().Trim();
        }
