    public class DataType
    {
        public static explicit operator bool(DataType D)
        {
            // TODO: Decide how you want to handle null references
            return D.ToBoolean();
        }
        protected virtual bool ToBoolean()
        {
            return false;
        }
    }
    public class MyBool : DataType
    {
        // ...
        protected override bool ToBoolean()
        {
            return Value;
        }
    }
