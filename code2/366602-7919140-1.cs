    public class ConditionValue
    {
        private object value;
        private IValueType valueType;
    
        public ConditionValue(object value, IValueType valueType)
        {
            this.value = value;
            this.valueType = valueType;
        }
    
        public bool GreaterThan(ConditionValue cv)
        {
            return valueType.GreaterThan(this.value, cv.value);
        }
    }
    
    public interface IValueType
    {
        bool GreaterThan(object left, object right);
    }
    
    public class IntegerType : IValueType
    {
        public bool GreaterThan(object left, object right)
        {
            int leftInt = (int)left;
            int rightInt = (int)right;
    
            return left > right;
        }
    }
