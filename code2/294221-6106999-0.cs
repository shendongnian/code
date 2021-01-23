    public static void AddStringParameterToAppender(this log4net.Appender.AdoNetAppender appender, string paramName, int size, string conversionPattern)
        {
            log4net.Appender.AdoNetAppenderParameter param = new log4net.Appender.AdoNetAppenderParameter();
            param.ParameterName = paramName;
            param.DbType = System.Data.DbType.String;
            param.Size = size;
            param.Layout = new log4net.Layout.Layout2RowLayoutAdapter(new log4net.Layout.PatternLayout(conversionPattern));
            appender.AddParameter(param);
        }
