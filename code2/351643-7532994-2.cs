    private Dictionary<object, Func<TrackingRecord, DbCommand>> conversionFunctions = new Dictionary<object, Func<TrackingRecord, DbCommand>>();
    public void RegisterConversionFunction<T>(Func<T, DbCommand> conversionFunction) where T : TrackingRecord
    {
        conversionFunctions.Add(typeof(T), tr => conversionFunction((T)tr));
    }
    public DbCommand GetConverstion<T>(T trackingRecord) where T : TrackingRecord
    {
        DbCommand command = null;
        Func<TrackingRecord, DbCommand> conversionFunction;
        if (conversionFunctions.TryGetValue(typeof(T), out conversionFunction))
            command = conversionFunction.Invoke(trackingRecord);
        else
            command = DefaultConversion(trackingRecord);
        return command;
    }
