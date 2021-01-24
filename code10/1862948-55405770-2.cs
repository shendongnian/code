    public class BaseVarDef<T>
    {
        public string DeveloperDescription { get; set; } = "";
        public T Value { get; private set; }
        public void SetValue(T value)
        {
            Value = value;
        }
        public void SetValue(BaseVarDef<T> value)
        {
            Value = value.Value;
        }
        public void ApplyChange(T amount)
        {
            AddToValue(amount);
        }
        public void ApplyChange(BaseVarDef<T> amount)
        {
            AddToValue(amount.Value);
        }
        private void AddToValue(T amount)
        {
            dynamic amt = amount;
            dynamic val = Value;
            // Empty catch to avoid runtime exception if 'T' doesn't support the '+' operator
            try { Value = amt + val; }
            catch { }           
        }
    }
