    public class CustomMap : Map
    {
    	public List<CustomPin> CustomPins { get; set; }
    
        public event EventHandler CallToNativeMethod;
    
        public void doSomething()
        {
            if (CallToNativeMethod != null)
                CallToNativeMethod(this, new EventArgs());
        }
    
        public void doSomething(CustomMap myMap) {
    
    
            MessagingCenter.Send<CustomMap>(this, "Hi");
    
        }
    }
