        public static List<List<T>> Transpose<T>(this List<List<T>> values)
        {
            if (values.Count == 0 || values[0].Count == 0)
            {
                return new List<List<T>>();
            }
            int ColumnCount = values[0].Count;
            var listByColumns = new List<List<T>>();
            foreach (int columnIndex in Enumerable.Range(0, ColumnCount))
            {
                List<T> valuesByColumn = values.Select(value => value[columnIndex]).ToList();
                listByColumns.Add(valuesByColumn);
            }
            return listByColumns;
        }            
