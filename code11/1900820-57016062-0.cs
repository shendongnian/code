    BsonClassMap.RegisterClassMap<Feature>(cm => {
        cm.AutoMap();
        cm.SetIsRootClass(true);
        var featureType = typeof(Feature);
        featureType.Assembly.GetTypes()
            .Where(type => featureType.IsAssignableFrom(type)).ToList()
            .ForEach(type => cm.AddKnownType(type));
    });
