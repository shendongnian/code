                List<String> answerData = new List<String>();
            Dictionary<string,int> map = new Dictionary<string, int>();
            foreach (var data in answerData)
            {
                if (map.ContainsKey(data))
                {
                    map[data]++;
                }
                else
                {
                    map.Add(data, 1);
                }
            }
            foreach (var item in map)
            {
                if (item.Value > 1)
                {
                    Console.WriteLine("{0} - {1}", item.Key, item.Value);
                }
            }
