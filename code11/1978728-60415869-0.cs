public class MyClass
{
    public TestNRClass TestNR { get; set; }
}
public class TestNRClass
{
    public string Name { get; set; }
    public string Description { get; set; }
}
// In the main,
string json = @"{""TestNr"":{""Name"":""CSHARP"", ""Description"":""Test Descriptiopn""}}";
MyClass jobj = JsonConvert.DeserializeObject<MyClass>(json);
Console.WriteLine(jobj.TestNR.Name);
This is with the strong typed class object. This is what you should be using in C#.
Other way is to get an object 
string json = @"{""TestNr"":{""Name"":""CSHARP"", ""Description"":""Test Descriptiopn""}}";
JObject obj = JObject.Parse(json);
Console.WriteLine(obj.ToString());
Console.WriteLine(obj["TestNr"]["Name"].ToString());
// You can also add more keyValuePair
obj["NewVariable"] = "stest";
Console.WriteLine(obj.ToString()); // Shows the new item as well.
