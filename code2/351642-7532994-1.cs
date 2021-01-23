    private Dictionary<object, Func<TrackingRecord, DbCommand>> conversionFunctions = new Dictionary<object, Func<TrackingRecord, DbCommand>>();
    public void RegisterConversionFunction<T>(Func<T, DbCommand> conversionFunction) where T : TrackingRecord
    {
        conversionFunctions.Add(typeof(T), tr => conversionFunction(tr as T));
    }
    public DbCommand GetConverstion<T>(T trackingRecord) where T : TrackingRecord
    {
        DbCommand command = null;
        if (conversionFunctions.ContainsKey(typeof(T)))
        {
            Func<TrackingRecord, DbCommand> conversionFunction;
            if (conversionFunctions.TryGetValue(trackingRecord.GetType(), out conversionFunction))
            {
                command = conversionFunction.Invoke(trackingRecord);
            }
        }
        else
        {
            command = DefaultConversion(trackingRecord);
        }
        return command;
    }
