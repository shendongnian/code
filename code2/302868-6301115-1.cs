    void Main()
    {
    	var m = new MyClass();
    	m.UnitType = 'L';
    	
    	var serializer = new System.Xml.Serialization.XmlSerializer(typeof(MyClass));
    	using(var sr = new StringWriter())
    	{
    		serializer.Serialize(sr, m);
    		Console.WriteLine(sr.GetStringBuilder().ToString());
    	}
    }
    
    public class MyClass
    {
    	public char UnitType { get; set; }
    }
