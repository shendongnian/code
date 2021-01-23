    class DynamicSqlRow : DynamicObject
    {
        System.Data.IDataReader reader;
        public DynamicSqlRow(System.Data.IDataReader reader)
        {
            this.reader = reader;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var row = reader[binder.Name];
            result = row is DBNull ? null : row;
            
            return true;
        }
    }
