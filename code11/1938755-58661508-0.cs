    .WriteTo(..., eventIdProvider: yourProvider)
---
        public static LoggerConfiguration EventLog(
            this LoggerSinkConfiguration loggerConfiguration,
            string source,
            string logName = null,
            string machineName = ".",
            bool manageEventSource = false,
            string outputTemplate = DefaultOutputTemplate,
            IFormatProvider formatProvider = null,
            LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum,
            IEventIdProvider eventIdProvider = null) // <#<#<#<#<#<#<#<#<#<#<#<#
