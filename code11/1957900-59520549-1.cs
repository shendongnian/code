csharp
[XmlType(typeName:"int")] // set its type explicitly for your desired output
public enum MyEnum : int
{        
   One,
}
public class ValueContainer
{
        public object Value;
}
class Program
{
   static void Main(string[] args)
   {
      var newSerializer = XmlSerializer.FromTypes(
           new[] { typeof(ValueContainer), typeof(MyEnum) })[0];
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
  <Value xsi:type="int">One</Value>
</ValueContainer>
Here is the [fiddle](https://dotnetfiddle.net/hZHKUg)
