class MyClass
{
   [JsonPropert("myProperty")]
   public MyChildClass MyProperty {get; set;}
   [JsonProperty("myNewProperty")] // -> Remember, case matters.
   public MyNewChildClass MyNewProperty {get; set;}
}
When you deserialize the class, add a check to see which is not null and work with that (different methods for each i guess). This should help you keep the breaking change to a minimum.
BTW>. if you have the code that converts the new to the old or vice versa, you can check if the value of old is null, then run that process/method you have to convert new to old and continue on with the object. Remember, it would have to be After the deserialization,
var properties = JsonConvert.DeserializeObject<MyClass>("data");
if (properties.MyNewProperty == null) 
{
   properties = myMethodToConvertOldToNew(properties);
}
public MyClass myMethodToConvertOldToNew(MyClass)
{
  if (properties.New == null)
  {
     properties.New = ConversionMethod(properties.Old, properties.New);
     // dont have to, but,
     properties.Old = null;
  }
  return properties.
}
