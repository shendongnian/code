            Dictionary<string, Dictionary<int, Dictionary<string, string>>> dic = new Dictionary<string, Dictionary<int, Dictionary<string, string>>>();
            //add to 1st dic:
            dic.Add("A", new Dictionary<int, Dictionary<string, string>>());
            //add to 2nd dic:
            dic["A"].Add(1, new Dictionary<string, string>());
            //add to 3rd dic:
            dic["A"][1].Add("a", "value 1");
            //string KeyIn3rdDic = dic["A"][1].ToString();
            string ValueIn3rdDic = dic["A"][1]["a"]; //result is "value 1";        
