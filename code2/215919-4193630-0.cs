        public bool FindExactMatch(int[] array, List<int> lst)
        {
            bool[] a34 = new bool[35];
            
            foreach(var item in array)
            {
                a34[item] = true;
            }
            int exact = 0;
            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i] < 35)
                {
                    if (a34[lst[i]])
                    {
                        exact++;
                        if (exact == array.Length)
                            return true;
                        a34[lst[i]] = false;
                    }
                }
            }
            return false;
        }
