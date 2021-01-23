        public bool IsObjectsEquals(Object Left, Object Right)
        {
            if (Left == null)
            {
                return Left == Right;
            }
            return Left.Equals(Right);
        }
        public List<T> ExcludeConsecutiveDuplicates<T>(List<T> InputList)
        {
            object lastItem = null;
            List<T> result = new List<T>();
            for (int i = 0; i < InputList.Count; i++)
            {
                if (i==0 || IsObjectsEquals(InputList[i],lastItem) != true)
                {
                    lastItem = InputList[i];
                    result.Add((T)lastItem);
                }
            }
            return result;
        }
