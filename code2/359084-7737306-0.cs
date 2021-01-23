        public T[] this[int x]
        {
            get
            {
                T[] result = new T[matrix.Count];
                for (int y = 0; y < matrix.Count; y++)
                {
                    result[y] = matrix[y][x];
                }
                return result;
            }
        }
