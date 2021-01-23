        public static Dictionary<string, List<string>> parseParameters(string val, List<string> l_lstValues) {
            var dic = new Dictionary<string, List<string>>();
            string curKey = string.Empty;
            foreach (string word in val.Split(' ')) {
                if (l_lstValues.Contains(word)) {
                    curKey = word;
                    continue;
                }
                if (curKey == string.Empty) {
                    throw new Exception("Error: word list should start with key");
                }
                if (!dic.ContainsKey(curKey))
                    dic[curKey] = new List<string>();
                dic[curKey].Add(word);
            }
            return dic;
        }
