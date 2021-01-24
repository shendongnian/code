C#
public class MyObject
{
   public string Name { get; set; }
}
public class MySecondObject
{
   public List<MyObject> DepObj { get; set; } = new List<MyObject>();
}
usage example:
C#
MyObject obj = new MyObject
{
    Name = "example"
};
MySecondObject mySecond = new MySecondObject();
mySecond.DepObj.Add(obj);
var data = new List<MySecondObject>
{
   mySecond
};
string json = JsonConvert.SerializeObject(data, Formatting.Indented);
System.IO.File.WriteAllText(@"D:\file.txt", json);
File content:
[
  {
    "DepObj": [
      {
        "Name": "example"
      }
    ]
  }
]
