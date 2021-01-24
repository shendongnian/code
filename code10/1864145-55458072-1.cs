    var result = dbContext.OperqationalDataItems
        .Where(operationalDataItem => ...)           // only if you don't want all
        .Select(operationalDataItem => new
        {
             Id = operationalDataItem.Id, 
             Community = operationalDataItem.Community
             AssetItems = operationalDataItem.AssetItems
                .Where(assetItem => ...)            // only if you don't want all its assetItems
                .Select(assetItem => new
                {
                    // Select only the properties you plan to use:
                    Id = assetItem.Id,
                    ...
                    // not useful: you know the value of the foreign key:
                    // OperationalDataId = assetItem.OperationalDataId,
                })
                .ToList();
        })
        .ToList();      // or: FirstOrDefault if you expect only one element
