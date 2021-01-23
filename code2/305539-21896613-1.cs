    class DynamicDataRow : DynamicObject
    {
        private readonly DataRow row;
    
        public DynamicDataRow(DataRow row)
        {
            this.row = row;
        }
    
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            DataColumn column = row.Table.Columns[binder.Name];
            if (column != null)
            {
                result = row[column];
                return true;
            }
    
            result = null;
            return false;
        }
    }
