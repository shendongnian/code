        public static List<string> GetList(string data)
        {
            data = data.Replace("\"", ""); // get rid of annoying "'s
            string[] S = data.Split(new string[] { "act=" }, StringSplitOptions.None);
            var results = new List<string>();
            foreach (string s in S)
            {
                if (!s.Contains("<tr"))
                {
                    string output = s.Substring(0, s.IndexOf(">"));
                    results.Add(output);
                }
            }
            return results;
        }
