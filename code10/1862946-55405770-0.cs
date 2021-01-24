    public class BaseVarDefExt<T> : BaseVarDef<T>
    {
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
            Value = amt + val;
        }
    }
