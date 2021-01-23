    public enum ErrorLevel { UserInputError, DatabaseError, OtherError... };
    public class BaseException : ApplicationException {
      protected ErrorLevel _errorLevel;
      ...
    }
