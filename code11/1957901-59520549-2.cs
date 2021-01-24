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
**EDIT : I fail to notice that value serialized as `<Value>One</Value>` this work around is dirtier than previous but it works.
[Fiddle](https://dotnetfiddle.net/IHLMUg)
