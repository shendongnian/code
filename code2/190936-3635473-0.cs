    using System;
    using System.Runtime.Serialization.Formatters.Soap;
    using System.IO;
    using System.Xml.Serialization;
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		Person p = new Person();
    		p.Age = 42;
    		p.Name = "Mr Smith";
    
    		FormatSoap(p);
    		FormatXml(p);
    	}
    
    	private static void FormatXml(Person p)
    	{
    		XmlSerializer serializer = new XmlSerializer(typeof(Person));
    		FileStream fs = new FileStream(@"c:\test\xmldata.txt", FileMode.Create);
    
    		serializer.Serialize(fs, p);
    	}
    
    	private static void FormatSoap(Person p)
    	{
    		SoapFormatter formatter = new SoapFormatter();
    		FileStream fs = new FileStream(@"c:\test\soapdata.txt", FileMode.Create);
    
    		formatter.Serialize(fs, p);
    	}
    }
    
    [Serializable]
    public class Person
    {
    	public int Age;
    	[XmlIgnore]
    	[NonSerialized]
    	public string Name;
    }
