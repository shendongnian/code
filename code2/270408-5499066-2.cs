    public abstract class Convert<T>:ConverterBase
    {
        private Func<string, T> ConverterFunction {get;set;}
    
        protected Convert(Func<string, T> converterFunction)
        {
            ConverterFunction = converterFunction;
        }
        
        public override object StringToField(string from)
        {
            try
            {
                return ConverterFunction(from);
            }
            catch (ArgumentException exception)
            {
                ThrowConvertException(from, exception.Message);
                return null;
            }
        }
    
        public override string FieldToString(object from)
        {
            return from.ToString();
        }
    
    }
