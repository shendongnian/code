    var result = dbContext.AssetItems
        .Where(assetItem => assetItem.AssetItmId = assetItemId)
        .Select(assetItem => new
        {
            // Select only the properties that you plan to use
            Id = assetItem.AssertItemId,
            Name = assetItem.Name,
            OperationalData = new
            {
                // again, select only the properties that you plan to use
                Id = assetItem.OperationalData.OperationalDataId,
                Community = assetItem.OperationalData.Community,
            },
        })
        .FirstOrDefault();
