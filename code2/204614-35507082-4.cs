        public class ValidationException : ApplicationException
        {
            public ValidationException()
            {
            }
            public ValidationException(string message)
                : base(message)
            {
            }
            public ValidationException(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
