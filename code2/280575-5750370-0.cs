    public class CalcNumber
    {
        public CalcNumberStatus Status {get; private set;}
        public double Value {get; private set;}
        
        
        public CalcNumber(double value)
        {
            Status = CalcNumberStatus.Normal;
            Value = value;
        }
        
        public CalcNumber(CalcNumberStatus status)
        {
            if(status == CalcNumberStatus.Normal)
            {
                throw new Exception("Cannot create a normal CalcNumber without a value");
            }
            Status = status;
            Value = 0;
        }
    }
    public enum CalcNumberStatus 
    {
        Normal,
        Error
    }
