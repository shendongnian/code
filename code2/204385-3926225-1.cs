    public class NewUserRegistrationException : Exception
    {
        public RegistrationErrorType Reason { get; private set; }
        public NewUserRegistrationException(RegistrationErrorType reason)
            : base()
        {
            Reason = reason;  
        }
        public NewUserRegistrationException(RegistrationErrorType reason, string message)
            : base(message)
        {
            Reason = reason;  //might as well create a custom message?
        }
        public NewUserRegistrationException(RegistrationErrorType reason, string message, Exception inner)
            : base(message, inner)
        {
            Reason = reason; //might as well create a custom message?
        }
    }
