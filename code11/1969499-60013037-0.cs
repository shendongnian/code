    public class MyObject
    {
        public int TemperatureCelsius { get; set; }
        public SomeObject SomeObject { get; set; }
    
        [OnError]
        internal void OnError(StreamingContext context, ErrorContext errorContext)
        {
            //You can check if exception is for a specific member then ignore it
            if(errorContext.Member.ToString().CompareTo("SomeObject") == 0)
            {
                errorContext.Handled = true;
            }
        }
    }
    
    public class SomeObject
    {
        public int High { get; set; }
        public int Low { get; set; }
    }
 
