     internal override void WriteDateTime(DateTime value) 
        {
            // ToUniversalTime() truncates dates to DateTime.MaxValue or DateTime.MinValue instead of throwing 
            // This will break round-tripping of these dates (see bug 9690 in CSD Developer Framework)
            if (value.Kind != DateTimeKind.Utc)
            {
                long tickCount = value.Ticks - TimeZone.CurrentTimeZone.GetUtcOffset(value).Ticks; 
                if ((tickCount > DateTime.MaxValue.Ticks) || (tickCount < DateTime.MinValue.Ticks))
                { 
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError( 
                        XmlObjectSerializer.CreateSerializationException(SR.GetString(SR.JsonDateTimeOutOfRange), new ArgumentOutOfRangeException("value")));
                } 
            }
            writer.WriteString(JsonGlobals.DateTimeStartGuardReader);
            writer.WriteValue((value.ToUniversalTime().Ticks - JsonGlobals.unixEpochTicks) / 10000); 
            switch (value.Kind) 
            { 
                case DateTimeKind.Unspecified:
                case DateTimeKind.Local: 
                    // +"zzzz";
                    TimeSpan ts = TimeZone.CurrentTimeZone.GetUtcOffset(value.ToLocalTime());
                    if (ts.Ticks < 0)
                    { 
                        writer.WriteString("-");
                    } 
                    else 
                    {
                        writer.WriteString("+"); 
                    }
                    int hours = Math.Abs(ts.Hours);
                    writer.WriteString((hours < 10) ? "0" + hours : hours.ToString(CultureInfo.InvariantCulture));
                    int minutes = Math.Abs(ts.Minutes); 
                    writer.WriteString((minutes < 10) ? "0" + minutes : minutes.ToString(CultureInfo.InvariantCulture));
                    break; 
                case DateTimeKind.Utc: 
                    break;
            } 
            writer.WriteString(JsonGlobals.DateTimeEndGuardReader);
        }
