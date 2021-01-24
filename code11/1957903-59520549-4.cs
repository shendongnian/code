csharp
public enum MyEnum
{        
   One,
}
public class ValueContainer
    {
        [XmlIgnore]
        private object _value;
        public object Value
        {
            get
            {
                return _value;
            }
            set
            {
                var type = value.GetType();
                _value = type.IsEnum ? (int)value : value;
            }
        }
    }
class Program
{
   static void Main(string[] args)
   {
      var newSerializer = XmlSerializer.FromTypes(
           new[] { typeof(ValueContainer))[0];
           var instance = new ValueContainer();
           instance.Value = MyEnum.One;
           var memoryStream = new MemoryStream();
           newSerializer.Serialize(memoryStream, instance);
           var str = Encoding.Default.GetString(memoryStream.ToArray());
     }
}
> Output
xml
<?xml version="1.0"?>
<ValueContainer xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Value xsi:type="xsd:int">0</Value>
</ValueContainer>
**EDIT :** I fail to notice that value serialized as `<Value>One</Value>` this work around is dirtier than previous but it works.
[Fiddle](https://dotnetfiddle.net/IHLMUg)
**EDIT 2 :** As @Victor Chelaru mentioned in the comments i decided to keep both workarounds but have to state that they both have the same drawback which is loosing type information on enum with serialized xml output.
csharp
[XmlType(typeName: "int",Namespace="http://www.w3.org/2001/XMLSchema")]
public enum MyEnum : int
{
	[XmlEnum("0")]
	One,
}
public class ValueContainer
{
	public object Value;
}
public static void Main()
{
	var newSerializer = XmlSerializer.FromTypes(new[]{typeof(ValueContainer), typeof(MyEnum)})[0];
	var instance = new ValueContainer();
	instance.Value = MyEnum.One;
	var memoryStream = new MemoryStream();
	newSerializer.Serialize(memoryStream, instance);
	var str = Encoding.Default.GetString(memoryStream.ToArray());
	str.Dump();
}
[Fiddle](https://dotnetfiddle.net/7h9bIm)
**Edit 3:** As @Simon Mourier  mentioned in the comments above workaround can be achieved without modifying enum directly with usage of `XmlAttributeOverrides` as below :
csharp
[XmlType(typeName: "int")]
public enum MyEnum : int
{		
	One,
}
public class ValueContainer
{
	public object Value;
}
public static void Main()
{				
	var ov = new XmlAttributeOverrides(); 
	ov.Add(typeof(MyEnum), nameof(MyEnum.One), new XmlAttributes { XmlEnum = new XmlEnumAttribute("0") }); 
	var newSerializer = new XmlSerializer(typeof(ValueContainer), ov, new[] { typeof(MyEnum) }, null, null);
	var instance = new ValueContainer();
	instance.Value = MyEnum.One;
	var memoryStream = new MemoryStream();
	newSerializer.Serialize(memoryStream, instance);
	var str = Encoding.Default.GetString(memoryStream.ToArray());
	str.Dump();
}
[Fiddle](https://dotnetfiddle.net/gHwlsk)
