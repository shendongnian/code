     Dictionary<int,Array> dict = new Dictionary<int, Array>();
                string[] Row = new string[4];
                Row[0] = "Data1";
                Row[1] = "Data2";
                Row[2] = "Data3";
                Row[3] = "Data4";
                dict.Add(1, Row);
    
                foreach (KeyValuePair<int, Array> item in dict)
                {
                    Console.WriteLine("Key: {0}, Value: {1} {2} {3} {4}", item.Key, item.Value.GetValue(0), item.Value.GetValue(1), item.Value.GetValue(2), item.Value.GetValue(3));
                }
