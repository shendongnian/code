    Camps.CollectionChanged += (ss, ee) =>
    {
        switch(ee.Action)
        {
            case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                Camp newObject = ee.NewItems[0] as Camp;
                ctx.Camps.Add(newObject);
                break;
        }
    };
