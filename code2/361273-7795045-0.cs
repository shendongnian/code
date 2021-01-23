    public static class DataTableX
    {
        public static IEnumerable<dynamic> AsDynamicEnumerable(this DataTable table)
        {
            return table.AsEnumerable().Select(row => new DynamicRow(row));
        }
    
        private sealed class DynamicRow : DynamicObject
        {
            private readonly DataRow _row;
    
            public DynamicRow(DataRow row)
            {
                _row = row;
            }
    
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                var retVal = _row.Table.Columns.Contains(binder.Name);
                result = retVal ? _row[binder.Name] : null;
                return retVal;
            }
        }
    }
