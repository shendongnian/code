    public class DataRowDictionaryWrapper : VirtualDictionary<string, object>
    {
        private DataRow row;
    
        public DataRowDictionaryWrapper(DataRow row)
        {
            this.row = row;
            this.wrappedDictionary = row.Table.Columns.Cast<DataColumn>().ToDictionary(key => key.ColumnName, c => row[c]);
        }
    
        public override void Add(string key, object value)
        {
            DataColumn col = row.Table.Columns[key];
            if (col == null)
            {
                col = new DataColumn(key);
                row.Table.Columns.Add(col);
            }
            row[col] = value;
    
            base[key] = value;
        }
    }
    public class DataTableDictionaryWrapper : IEnumerable<IDictionary<string, object>>
    {
        private DataTable dt;
    
        public DataTableDictionaryWrapper(DataTable dt)
        {
            this.dt = dt;
        }
    
        public IEnumerator<IDictionary<string, object>> GetEnumerator()
        {
            foreach (DataRow row in dt.Rows)
            {
                yield return new DataRowDictionaryWrapper(row);
            }
        }
    
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
