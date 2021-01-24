    public class InvalidConnectionModelException : Exception
    {
        public string[] ErrorMessages { get; }
        public InvalidConnectionModelException(string[] errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
    // Throw own exception
    internal static bool Validate(ConnectionModel connectionModel)
    {
        var validator = new ConnectionModelValidator();
        var result = validator.Validate(connectionModel);
        if (result.IsValid) 
        {
            return true;
        }
        var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToArray();
        throw new InvalidConnectionModelException(errorMessages);
    }
