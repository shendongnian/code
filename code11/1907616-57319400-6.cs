        private static readonly ILog log = LogManager.GetLogger(typeof(ErrorHandler));
        /// <summary>
        /// Applies a new path for the log file by FileAppender name
        /// </summary>
        public static void SetLogPath()
        {
            XmlConfigurator.Configure();
            log4net.Repository.Hierarchy.Hierarchy h = (log4net.Repository.Hierarchy.Hierarchy)LogManager.GetRepository();
            string logFileName = System.IO.Path.Combine(Properties.Settings.Default.App_PathLocalData, AssemblyInfo.Product + ".log");
            foreach (var a in h.Root.Appenders)
            {
                if (a is log4net.Appender.FileAppender)
                {
                    if (a.Name.Equals("FileAppender"))
                    {
                        log4net.Appender.FileAppender fa = (log4net.Appender.FileAppender)a;
                        fa.File = logFileName;
                        fa.ActivateOptions();
                    }
                }
            }
        }
        /// <summary>
        /// Create a log record to track which methods are being used.
        /// </summary>
        public static void CreateLogRecord()
        {
            try
            {
                // gather context
                var sf = new System.Diagnostics.StackFrame(1);
                var caller = sf.GetMethod();
                var currentProcedure = caller.Name.Trim();
                // handle log record
                var logMessage = string.Concat(new Dictionary<string, string>
                {
                    ["PROCEDURE"] = currentProcedure,
                    ["USER NAME"] = Environment.UserName,
                    ["MACHINE NAME"] = Environment.MachineName
                }.Select(x => $"[{x.Key}]=|{x.Value}|"));
                log.Info(logMessage);
            }
            catch (Exception ex)
            {
                ErrorHandler.DisplayMessage(ex);
            }
        }
        /// <summary> 
        /// Used to produce an error message and create a log record
        /// <example>
        /// <code lang="C#">
        /// ErrorHandler.DisplayMessage(ex);
        /// </code>
        /// </example> 
        /// </summary>
        /// <param name="ex">Represents errors that occur during application execution.</param>
        /// <param name="isSilent">Used to show a message to the user and log an error record or just log a record.</param>
        /// <remarks></remarks>
        public static void DisplayMessage(Exception ex, Boolean isSilent = false)
        {
            // gather context
            var sf = new System.Diagnostics.StackFrame(1);
            var caller = sf.GetMethod();
            var errorDescription = ex.ToString().Replace("\r\n", " "); // the carriage returns were messing up my log file
            var currentProcedure = caller.Name.Trim();
            var currentFileName = AssemblyInfo.GetCurrentFileName();
            // handle log record
            var logMessage = string.Concat(new Dictionary<string, string>
            {
                ["PROCEDURE"] = currentProcedure,
                ["USER NAME"] = Environment.UserName,
                ["MACHINE NAME"] = Environment.MachineName,
                ["FILE NAME"] = currentFileName,
                ["DESCRIPTION"] = errorDescription,
            }.Select(x => $"[{x.Key}]=|{x.Value}|"));
            log.Error(logMessage);
            // format message
            var userMessage = new StringBuilder()
                .AppendLine("Contact your system administrator. A record has been created in the log file.")
                .AppendLine("Procedure: " + currentProcedure)
                .AppendLine("Description: " + errorDescription)
                .ToString();
            // handle message
            if (isSilent == false)
            {
                MessageBox.Show(userMessage, "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
