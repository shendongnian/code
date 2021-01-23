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
    
    public interface IValueType<TType>
    {
        bool GreaterThan(TType left, TType right);
    }
    
    public class IntegerType : IValueType<int>
    {
        public bool GreaterThan(int left, int right)
        {
            return left > right;
        }
    }
