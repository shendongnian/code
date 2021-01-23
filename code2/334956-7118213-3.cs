       Predicate<int> checkFactory;
       IDictionary<ItemType, Predicate<int>> checkFactoryProvider = new ...
       if (checkFactoryProvider.ContainsKey(ItemType.ActualityDurationMask)
       {
            checkFactory = checkFactoryProvider[ItemType.ActualityDurationMask];
       }
    
        // check for nulls ets
        if (checkFactory (_VIF))
        {
            mTimeType = TimeType.ActualityDuration;
            SetTimeRange();
        }
