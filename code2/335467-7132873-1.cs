    internal static class DataReaderFactory
    {
        internal static IDataReader GetReader<T>(string typeName, List<T> items)
        {
            IDataReader reader = null;
            switch(typeName)
            {
                case "ProductRecordDataReader":
                    reader =  new ProductRecordDataReader(items as List<ProductRecord>) as IDataReader;
                    break;
                case "RetailerPriceRecordDataReader":
                    reader =  new RetailerPriceRecordDataReader(items as List<RetailerPriceRecord>) as IDataReader;
                    break;
                default:
                    break;
            }
            return reader;
        }
    }
