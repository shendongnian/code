    public class CustomField<T>
    {
        public string Internalid
        {
            get;
            set;
        }
        public T Value
        { 
            get;
            set;
        }
    
        public virtual string GetStringRepresentation()
        {
            return Value.ToString();
        }
    }
    
    public class DateCustomField : CustomField<DateTime>
    {
        public override string GetStringRepresentation()
        {
             return Value.ToShortDateString();
        }
    }
