    internal static class DBHelpers
    {
        public static string GetTableName<TDBItem>()
            where TDBItem : DBItem
        {
            var attribute = typeof(TDBItem).GetCustomAttribute<DBItemAttribute>();
            return attribute?.TableName;
        }
    }
