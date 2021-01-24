        private static List<List<int>> FindSequence(int[] array)
        {
            var result = new List<List<int>>();
            var tempList  = new List<int>{array[0]};
            var lastResult = array[0];
            for (var i = 1; i < array.Length; i++)
            {
                if(lastResult==array[i]+1)
                    tempList.Add(array[i]);
                else
                {
                    result.Add(tempList);
                    tempList = new List<int> {array[i]};
                }
            }
            result.Add(tempList);
            return result;
        }
