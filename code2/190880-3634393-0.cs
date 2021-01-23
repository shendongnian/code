    public static void ReportError(Exception exceptionRaised, string reference, string customMessage, bool sendEmail)
    {
		// build up message from exception, reference & custom message using string builder
		ProcessError(Message, SendEmail)
    }
    public static void ReportError(string errorMessage, string reference, bool sendEmail)
    {
		// build up message from errorMessage & reference string builder
		ProcessError(Message, SendEmail)
    }
    private static void ProcessError(string message, bool sendEmail)
    {
		// get filename
		// check if logfile exists, blah, blah
		// save message
		// email error (if set)
    }
