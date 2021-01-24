    public class BaseClass
    {
    	public string MyProperty0 { get; set; }
    }
    
    public class TestClass : BaseClass
    {
    	public int MyProperty1 { get; set; }
    	public string MyProperty2 { get; set; }
    }
    
    public static string SerializeBaseClass<T>(T item) where T : BaseClass
    {
    	return JsonConvert.SerializeObject(item);
    }
    
    static void Main(string[] args)
    {
    	var item = new TestClass { MyProperty0 = "11111", MyProperty1 = 1, MyProperty2 = "1111" };
    
    	string serializedItem, serializedType;
    
    	serializedType = item.GetType().FullName;
    	serializedItem = SerializeBaseClass(item);
    
    	Console.WriteLine(serializedType);
    	Console.WriteLine(serializedItem);
    
    	var deserializedType = Type.GetType(serializedType);
    	var deserializedItem = JsonConvert.DeserializeObject(serializedItem, deserializedType);
    
    	Console.WriteLine(deserializedItem.GetType().FullName);
    
    	Console.ReadKey();
    }
