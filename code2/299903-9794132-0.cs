    public class ErrorHandler : IErrorHandler
    {
        private readonly Action<Exception> LogException;
        private readonly Action<Message> LogFault;
        public ErrorHandler(Action<Exception> logException, Action<Message> logFault)
        {
            LogException = logException;
            LogFault = logFault;
        }
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException) // Thrown by WCF - eg request deserialization problems, can be explicitly thrown in code
            {
                LogFault(fault);
                return;
            }
            var faultCode = new FaultCode("UnknownFault");
            if (error is ArgumentOutOfRangeException)
            {
                faultCode = new FaultCode("ArgumentOutOfRange");
            }
            var action = OperationContext.Current.IncomingMessageHeaders.Action;
            fault = Message.CreateMessage(version, faultCode, error.Message, action);
            LogFault(fault);
        }
        public bool HandleError(Exception error)
        {
            // Logging of exceptions should occur here as all exceptions will hit HandleError, but some will not hit ProvideFault
            LogException(error);
            return false; // false allows other handlers to be called - if none return true the dispatcher aborts any session and aborts the InstanceContext if the InstanceContextMode is anything other than Single.
        }
    }
