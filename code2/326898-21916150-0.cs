      /// <summary>
        /// Send DataTable as dapper parameter
        /// </summary>
        public class DapperTableParameter : ICustomQueryParameter
        {
            protected DataTable _table = null;
    
            public DapperTableParameter(DataTable table)
            {
                _table = table;
            }
    
            public void AddParameter(System.Data.IDbCommand command, string name)
            {
                // This is SqlConnection specific
                ((SqlCommand)command).Parameters.Add("@" + name, SqlDbType.Structured).Value = _table;
            }
        }
    
    
    
    public class DapperTVP<T> : DapperTableParameter
        {
            public DapperTVP(IEnumerable<T> list) : base(new System.Data.DataTable())
            {
                var t = typeof(T);
                var propertyByName = new Dictionary<string, PropertyInfo>();
    
                foreach (var p in t.GetProperties())
                {
                    propertyByName.Add(p.Name, p);
                    _table.Columns.Add(p.Name, p.PropertyType);
                }
    
                foreach (var i in list)
                {
                    var row = _table.NewRow();
                    foreach (var p in propertyByName)
                    {
                        row[p.Key] = p.Value.GetValue(i, null);
                    }
                    
                    _table.Rows.Add(row);
                }
            }
        }
