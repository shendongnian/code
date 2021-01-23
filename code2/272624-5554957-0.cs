    public interface IRuleDefinition
    {
        String PropertyName { get; }
        String Message { get; }
    }
    
    public class ValidationRule<T>: IRuleDefinition
    {
        public String PropertyName { get; private set; }
        public String Message { get; private set; }
        
        private Func<T, Boolean> _isValidDelegate;
    
        public ValidationRule(Func<T, Boolean> isValidDelegate, String propertyName, String message)
        {
            PropertyName = propertyName;
            Message = message;
            _isValidDelegate = isValidDelegate;
        }
    
        public Boolean IsValid(T objToValidate)
        {
            return _isValidDelegate(objToValidate);
        }
    }
    
    public class Validator<T>
    {
        private List<ValidationRule<T>> _validationRules = new List<ValidationRule<T>>();
        
        public void AddRule(Func<T, Boolean> isValidDelegate, String propertyName = null, String message = null)
        {
            _validationRules.Add(new ValidationRule<T>(isValidDelegate, propertyName, message));
        }
    
        public Boolean IsValid(T objToValidate)
        {
            return _validationRules.Any(vr => vr.IsValid(objToValidate));
        }
    
        public IEnumerable<IRuleDefinition> GetViolations(T objToValidate)
        {
            return _validationRules
                 .Where(vr => !vr.IsValid(objToValidate))
                 .Cast<IRuleDefinition>();
        }
    }
