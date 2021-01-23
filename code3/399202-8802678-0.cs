    var duplicates =  
    from typeMappings in _liveTable.Where(r =>
        (r.ProviderId == providerId) && (r.ExchangeId == exchangeId))
    join dataDictionary in _liveDataSet.DataDictionary.Where(r => 
        (r.DataDictionaryTypeId == dataDictionaryTypeId)) 
    on typeMappings.DataDictionaryId equals dataDictionary.DataDictionaryId
    select new
           { ConfigId = typeMappings.ConfigId = null ? "anyValueyouwhant" : typeMappings.ConfigId};
