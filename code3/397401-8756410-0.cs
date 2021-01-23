    private static void TestZip()
        {
            Dictionary<string, string> stringstringdic = new Dictionary<string, string>();
            stringstringdic.Add("1", "One");
            stringstringdic.Add("2", "Two");
            stringstringdic.Add("3", "Three");
            stringstringdic.Add("4", "Four");
            stringstringdic = stringstringdic.Where(pair => pair.Key != "1")
                                             .ToDictionary(pair => pair.Key, pair => pair.Value);
            List<string> stringlist = stringstringdic.Keys.Concat(stringstringdic.Values).ToList();
            foreach (string str in stringlist)
            {
                Console.WriteLine(str);
            }
        }
    
    //Output:    
    //2
    //3
    //4
    //Two
    //Three
    //Four
