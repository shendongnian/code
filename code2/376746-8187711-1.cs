    public interface ISomeOtherInterface
    {
 	ISettings Settings { get; set; }
    }
    public class DeSerializeHelper<T>
    {
        public static T Deserialize(string path)
        {
	   T instance = default(T);
	   var serializer = new XmlSerializer(typeof(TestData));
	   using (TextReader r = new StreamReader(path, Encoding.UTF8))
	   {
	      instance = (T)serializer.Deserialize(r);
	   }
	   return instance;
        }
    }
    ISomeOtherInterface instance = DeSerializeHelper.Deserialize<SomeOtherInterfaceImplementation>(@"%temp%\sample.xml")
