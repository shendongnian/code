public class MyClass
{
    public string SomeProperty { get; set; }
    public string AnotherProperty { get; set; }
}
Usage:
if (message.IsSuccessStatusCode)
{
     var deserializedObject = JsonConvert.DeserializeObject<MyClass>(response.Content.ReadAsStringAsync().Result);
     Console.WriteLine(deserializedObject.SomeProperty);
}
