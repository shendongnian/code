    void Main()
    {
            const int testValue=5;
    	var test = (Test)Activator.CreateInstance(typeof(Test));
    	PropertyInfo valuePropertyInfo = typeof(Test).GetProperty("Value");
    	valuePropertyInfo.SetValue(test, testValue, null);
    	int value = (int)valuePropertyInfo.GetValue(test, null);
    	Console.Write(value);   //Assert here instead
    	
    }
    public class Test
    {
    private int _value;
    public int Value {get {return _value;}  set{_value=Value;}}
    }
