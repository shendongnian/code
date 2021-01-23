    ...
   
    if (value.Kind != DateTimeKind.Utc)
    {
        long num = value.Ticks - TimeZone.CurrentTimeZone.GetUtcOffset(value).Ticks;
        if ((num > DateTime.MaxValue.Ticks) || (num < DateTime.MinValue.Ticks))
        {
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(XmlObjectSerializer.CreateSerializationException(SR.GetString("JsonDateTimeOutOfRange"), new ArgumentOutOfRangeException("value")));
        }
    }
    ...
