    public static string outputDictionaryContents(Dictionary<string, int> list)
            {
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, int> pair in list)
                {
                    StringBuilder.AppendFormat("{0}, {1}", pair.Key, pair.Value);
                }
                return sb.ToString();
            }
