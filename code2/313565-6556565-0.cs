        public static IAzureTable<T> GetTable<T>(string datastoreValue, string tableName = null)
        {
            tableName = tableName ?? typeof (T).Name + "s";
            return new AzureTable<T>(GetStorageAccount(datastoreValue), tableName);
        }
