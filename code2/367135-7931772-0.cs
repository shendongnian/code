            string[] col1 = new string[] { "AAA", "BBB", "CCC" };
            string[] col2 = new string[] { "BBB", "CCC", "DDD" };
            Dictionary<string, int> colDic = new Dictionary<string, int>();
            foreach (var item in col1)
            {
                int num;
                if (colDic.TryGetValue(item, out num))
                    colDic[item] = num - 1;
                else
                    colDic[item] = -1;
            }
            foreach (var item in col2)
            {
                int num;
                if (colDic.TryGetValue(item, out num))
                    colDic[item] = num + 1;
                else
                    colDic[item] = 1;
            }
