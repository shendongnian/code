    public static class EFTracingExtensions
    {
        private static ILogger _logger;
        public static void InitSqlTracing(ILogger logger)
        {
            _logger = logger;
            EFTracingProviderConfiguration.RegisterProvider();
            if (logger.IsLoggingEnabled())          // Don't add logging hooks if logging isn't enabled
            {
                EFTracingProviderConfiguration.LogAction = new Action<CommandExecutionEventArgs>(AppendSqlLog);
            }
        }
        private static void AppendSqlLog(CommandExecutionEventArgs e)
        {
            if (e.Status != CommandExecutionStatus.Executing)               // we only care about Finished and Failed
            {
                StringBuilder msg = new StringBuilder(e.ToTraceString().TrimEnd());
                msg.Append(Environment.NewLine);
                if (e.Result is SqlDataReader)
                {
                    int rows = ((SqlDataReader)e.Result).HasRows ? ((SqlDataReader)e.Result).RecordsAffected : 0;
                    msg.AppendFormat("*** {0} rows affected", rows);
                }
                else if (e.Result is int)
                {
                    msg.AppendFormat("*** result: {0}", e.Result);
                }
                else
                {
                    msg.AppendFormat("*** finished, result: {0}", e.Result);
                }
                msg.Append(Environment.NewLine);
                msg.AppendFormat(" [{0}] [{1}] in {2} seconds", e.Method, e.Status, e.Duration);
                _logger.Log(msg.ToString(), LoggerCategories.SQL);
            }
        }
    }
