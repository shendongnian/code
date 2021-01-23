        public static string[] Split(string val, List<string> l_lstValues) {
            var dic = new Dictionary<string, List<string>>();
            string curKey = string.Empty;
            foreach (string word in val.Split(' ')) {
                if (l_lstValues.Contains(word)) {
                    curKey = word;
                }
                if (!dic.ContainsKey(curKey))
                    dic[curKey] = new List<string>();
                dic[curKey].Add(word);
            }
            return dic.Keys.ToArray();
        }
