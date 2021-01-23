        class DataRowEqualityComparer : IEqualityComparer<DataRow>
        {
            public bool Equals(DataRow x, DataRow y)
            {
                // perform cell-by-cell comparison here
                return result;
            }
            public int GetHashCode(DataRow obj)
            {
                return base.GetHashCode();
            }
        }
        // ...
        var comparer = new DataRowEqualityComparer();
        var filteredRows = from row in dtCSV.Rows
                           select row.Distinct(comparer);
