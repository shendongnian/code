    public static string GetDictionaryContents(Dictionary<string, int> list)
        {
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, int> pair in list)
            {
                builder.AppendFormat("{0}, {1}{2}", pair.Key, pair.Value, Environment.NewLine);
            }
            return builder.ToString();
        }
