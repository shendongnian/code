    public interface IValidator
    {
        IEnumerable<ValidationResult> Validate(object entity);
    }
    public class ValidationResult
    {
        public ValidationResult(string key, string message)
        {
            this.Key = key;
            this.Message = message; 
        }
        public string Key { get; }
        public string Message { get; }
    }
    public class ValidationException : Exception
    {
        public ValidationException(ValidationResult[] r) : base(r[0].Message)
        {
            this.Errors = new ReadOnlyCollection<ValidationResult>(r);
        }
        
        public ReadOnlyCollection<ValidationResult> Errors { get; }            
    }    
    
