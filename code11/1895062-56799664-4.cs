    public interface IErrorDetails {
        DataRow Entity { get; }
        EntityValidationRule Rule { get; }
        String ErrorMessage { get; }
    }
