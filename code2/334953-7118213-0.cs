    // You can decouple check functions and actuall logic by 
    // introducing predicate per item type, then try to figure out whether you can
    // abstract each block inside `if(predicate()) { ...here.. }` 
    // into the separate factories using `Func<,>`
  
    // Check predicate
    Predicate<int> actualityDurationCheck = (vif) => 
                                            (vif & ActualityDurationMask) == 0;
    if (actualityDurationCheck(_VIF))
    {
        mTimeType = TimeType.ActualityDuration;
        SetTimeRange();
    }
