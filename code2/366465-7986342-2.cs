    public class PropertyValidationResultItem : ValidationResultItem
    {        
        public PropertyValidationResultItem(ResultType resultType, string message, string propertyName, object attemptedValue) : base(resultType, message)
        {            
            PropertyName = propertyName;           
            AttemptedValue = attemptedValue;
        }
        
        public string PropertyName { get; private set; }        
        public object AttemptedValue { get; private set; }             
    }
