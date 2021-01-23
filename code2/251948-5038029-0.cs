    Dictionary<string, dynamic> Dict = new Dictionary<string, dynamic>();
    Dict.Add("int", new List<int>());
    Dict.Add("string", new List<string>());
    
    Dict["int"].Add(12);
    Dict["string"].Add("str");
            foreach (KeyValuePair<string, dynamic> pair in Dict) {
                Type T = pair.Value.GetType();
                Console.WriteLine(T.GetGenericArguments()[0].ToString());
            }
