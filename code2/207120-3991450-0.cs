    private IEnumerable<ConfigMetaDataCombinedColumns> ReturnMe()
    {
       var query = from meta in GetConfigMetaData().AsQueryable()
                join data in GetConfigDataColumns().AsQueryable()
                on meta.FieldID equals data.FieldID
                select new {
                    ConfigMetaDataColumns = meta,
                    ConfigDataColumns = data
                };
       return  from item in query
                group item by item.ConfigMetaDataColumns into l 
                select new ConfigMetaDataCombinedColumns()
                {
                    ConfigMetaData = l.Key,
                    ConfigData = l.Select(x=>x.ConfigDataColumns)
    
                }        ;
    }
