public class MyClass
{
    public string Email { get; set; }
    public string Name {get; set; }
    // ... and so on with other properties
    public MyClass(string csvLine)
    {
        // Here parse the line and fill the properties
    }
}
 3. Override the ToString() function in this class and perform here the JSON serialization (using for example the function `System.Web.Script.Serialization.JavaScriptSerializer().Serialize(string)`:
public class MyClass
{      
    // ...
    public override string ToString()
    {
        return new JavaScriptSerializer().Serialize(this);
    }
}
Your code will be something like:
while (!reader.EndOfStream)
{
    var line = reader.ReadLine();
    MyClass mc = new MyClass(line);
    string jsonString = mc.ToString();
}
