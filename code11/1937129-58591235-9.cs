     public class SqlServerSemesterTypeMapping : DateTimeTypeMapping
    {
        public SqlServerSemesterTypeMapping(string storeType, DbType? dbType = null) : 
            base(storeType, dbType)
        {
        }
        protected SqlServerSemesterTypeMapping(RelationalTypeMappingParameters parameters) : base(parameters)
        {
        }
        protected override RelationalTypeMapping Clone(RelationalTypeMappingParameters parameters) => new SqlServerSemesterTypeMapping(parameters);
    }
