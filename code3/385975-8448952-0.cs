        public IEnumerable<T> this[int x, int y, int width, int length]
        {
            get
            {
                for (int i = 0; i < length; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        for (int k = 0; k < map[x + i, y + j].Length; k++)
                        {
                            yield return map[x + i, y + j][k];
                        }
                    }
                }
            }
        }
