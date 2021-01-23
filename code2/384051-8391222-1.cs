        private List<int[]> CombinedElementsInArrayLessThanValue(int[] foo, int value)
        {
            List<int[]> list = new List<int[]>();
            for (int i = 0; i < foo.Length; i++)
            {
                List<int> start = new List<int>();
                start.Add(foo[i]);
                start.Sort();
                int[] clone = start.ToArray();
                if (start.Sum() < value && !list.Contains(clone))
                {
                    list.Add(clone);
                    CombinedElementsInArrayLessThanValue(foo, value, start, list);
                }
            }
            return list;
        }
        private void CombinedElementsInArrayLessThanValue(int[] foo, int value, List<int> partial, List<int[]> accumulate_result)
        {
            for (int i = 0; i < foo.Length; i++)
            {
                List<int> clone = new List<int>(partial);
                clone.Add(foo[i]);
                clone.Sort();
                int[] array = clone.ToArray();
                if (clone.Sum() < value && !accumulate_result.Contains(array))
                {
                    accumulate_result.Add(array);
                    CombinedElementsInArrayLessThanValue(foo, value, clone, accumulate_result);
                }
            }
        }
