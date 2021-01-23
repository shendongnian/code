        private static IEnumerable<Set> GetSets(List<int> src)
        {
            List<Set> rtn = new List<Set>();
            int previous = int.MaxValue;
            foreach (int i in src)
            {
                if (i == previous + 1)
                {
                    rtn[rtn.Count - 1].Count += 1;
                }
                else
                {
                    rtn.Add(new Set() { Start = i, Count = 1 });
                }
                previous = i;
            }
            return rtn;
        }
