    internal static void HandleException(Exception ex)
    {
        var exDetail = String.Format(ExceptionFormatString,
            ex.Message,
            Environment.NewLine,
            ex.Source,
            ex.StackTrace,
            ex.InnerException);
    
        ExceptionLoggingService.Instance.LogAndEmailExceptionData(string.Format("{0}: {1}: {2}",
            DateTime.Now.ToLongDateString(), GetVersionInfo(), exDetail));
    }
