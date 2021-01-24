    public class CustomTableNameConvention : IStoreModelConvention<EntitySet>
    {
        private readonly string _tablePrefix;
        public CustomTableNameConvention(string tablePrefix)
        {
            _tablePrefix = tablePrefix;
        }
        public void Apply(EntitySet item, DbModel model)
        {
            //change table name.
            item.Table = $"{_tablePrefix}" + item.Table;
        }
    }
