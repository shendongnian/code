csharp
var myResponseClass = new MyResponseClass();
dynamic myClass = JsonSerializer.Deserialize<ExpandoObject>("{\"fixedProperty\":\"Hello\",\"dynamicProperty\": {\"attributeOne\":\"One\",\"attributeTwo\":\"Two\"}}");
dynamic myProperty = JsonSerializer.Deserialize<ExpandoObject>(myClass.dynamicProperty.ToString());
myResponseClass.FixedProperty = myClass.fixedProperty.ToString();
myResponseClass.DynamicProperty = myProperty;
