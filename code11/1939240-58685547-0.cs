    var assetDetails = context.Assets
        .Select(x => new 
        { 
            Asset = x, 
            CurrentDocument = x.Movements
                .OrderByDescending(m => m.Document.DocumentDate)
                .Select(m => m.Document)
                .FirstOrDefault()
        }).Single(x => x.Asset.AssetId == assetId);
