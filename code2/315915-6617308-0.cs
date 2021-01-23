    SortedList<string, StringBuilder> listOfLists = new SortedList<string, StringBuilder>();
    string[] keyPairs = test.Split(',');
    foreach (string keyPair in keyPairs)
    {
        string[] item = keyPair.Split(':');
        if (item.Length >= 3)
        {
            string nextValue = string.Format("{0}:{1}", item[1].Trim(), item[2].Trim());
            if (listOfLists.ContainsKey(item[0]))
                listOfLists[item[0]].Append(nextValue);
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(nextValue);
                listOfLists.Add(item[0], sb);
            }
        }
    }
    foreach (KeyValuePair<string, StringBuilder> nextCollated in listOfLists)
        System.Console.WriteLine(nextCollated.Key + ":" + nextCollated.Value.ToString());
