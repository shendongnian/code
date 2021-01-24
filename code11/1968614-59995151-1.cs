        public class Error
        {
            public int Code { get; }
            public Guid? CorrelationId { get; }
            public DateTime DateUtc { get; }
            public string ErrorMessage { get; }
            public string ErrorType { get; }
    
            public Error(HttpStatusCode code, Guid? correlationId, string errorMessage, string errorType)
            {
                Code = (int)code;
                CorrelationId = correlationId;
                DateUtc = DateTime.UtcNow;
                ErrorMessage = errorMessage;
                ErrorType = errorType;
            }
        }
