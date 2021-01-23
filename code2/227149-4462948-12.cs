    public class MyClass
    {
    	// note that this type of property declaration is called an "Automatic Property" and
    	// it means the same thing as you had written (the private backing variable is used behind the scenes, but you don't see it)
    	public List<KeyValuePair<string, string> MySettings { get; set; } 
    }
    
    public class MyConsumingClass
    {
    	public void MyMethod
    	{
    		MyClass myClass = new MyClass();
    		myClass.MySettings = new List<KeyValuePair<string, string>>();
    		myClass.MySettings.Add(new KeyValuePair<string, string>("SomeKeyValue", "SomeValue"));
    		
    		// etc.
    	}
    }
