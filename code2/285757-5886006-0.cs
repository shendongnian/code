    public interface IWhatever 
    {
       bool Value { get; set;}
    }
    public class Whatever : IWhatever 
    {
        public bool Value { get; set; }
    
        public Whatever()
        { 
            Value = true;
        }
    }
