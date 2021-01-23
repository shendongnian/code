        public T[,] RemoveRow<T>(T[,] array2d, int rowToRemove)
        {
            var resultAsList = Enumerable
                .Range(0, array2d.GetLength(0))  // select all the rows available
                .Where(i => i != rowToRemove)    // except for the one we don't want
                .Select(i =>                     // select the results as a string[]
                {
                    T[] row = new T[array2d.GetLength(1)];
                    for (int column = 0; column < array2d.GetLength(1); column++)
                    {
                        row[column] = array2d[i, column];
                    }
                    return row;
                }).ToList();
            // convert List<string[]> to string[,].
            return CreateRectangularArray(resultAsList); // CreateRectangularArray() can be copied from http://stackoverflow.com/a/9775057
        }
