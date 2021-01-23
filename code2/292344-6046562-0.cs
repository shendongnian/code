        public void Test()
        {
            List<string> source = new List<string> {
                "key1 some data",
                "key2 some more data",
                "key3 yada..."};
            Dictionary<string, string> resultDictionary = source.ToDictionary(n => n.Split(' ').First, n => n.Substring(n.IndexOf(' ')));
            List<string> resultStrings = source.Select(n => string.Format("\"{0}\",{1}", n.Split(' ').First, n.Substring(n.IndexOf(' ')))).ToList;
        }
