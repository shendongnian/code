    public abstract class DataType
    {
        public static explicit operator bool(DataType D)
        {
            return DoCastToBool(D);
        }
    
        public static explicit operator DataType(bool B)
        {
            return DoCastFromBool(B);
        }
    
        protected abstract bool DoCastToBool();
        protected abstract DataType DoCastFromBool();
    }
