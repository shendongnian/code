            List<List<int>> lists = new List<List<int>>();
            int lastValue = 0;
            int countOfCurrent = 0;
            for(int i = 0; i < list.Count; i++)
            {
                int value = list[i];
                if(value == lastValue && i > 0)
                {
                    countOfCurrent++;
                } else
                {
                    countOfCurrent = 0;
                }
                if(countOfCurrent >= lists.Count)
                {
                    lists.Add(new List<int> { value });
                } else
                {
                    lists[countOfCurrent].Add(value);
                }
                lastValue = value;
            }
