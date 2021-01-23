        public static IAzureTable<T> GetTable<T>(string datastoreValue, string tableName = null) where T : TableServiceEntity
        {
            var pluralizationService = PluralizationService.CreateService(new CultureInfo("en-US"));
            tableName = tableName ?? pluralizationService.Pluralize(typeof(T).Name);
            return new AzureTable<T>(GetStorageAccount(datastoreValue), tableName);
        }
