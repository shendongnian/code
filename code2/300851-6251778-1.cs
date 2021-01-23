    public abstract class DataType
    {
        public static explicit operator bool(DataType D)
        {
            return D.DoCastToBool();
        }
    
        public static explicit operator DataType(bool B)
        {
            // We haven’t got an instance of our class here.
            // You can use a factory method pattern to emulate virtual constructors.
        }
    
        protected abstract bool DoCastToBool();
    }
