    public class ErrorDetails : IErrorDetails {
        public ErrorDetails(DataRow entity, EntityValidationRule rule, String errorMessage) {
            Entity = entity;
            Rule = rule;
            ErrorMessage = errorMessage;
        }
        public DataRow Entity { get; }
        public EntityValidationRule Rule { get; }
        public String ErrorMessage { get; }
    }
