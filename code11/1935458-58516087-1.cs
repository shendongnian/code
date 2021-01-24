public class NodeModel<T>
{
   (...)
   public T Props { get;  set; }
}
you could then help the desrialiser by telling it what type to use.
serialiser.DeserialiseObject<NodeModel<SomeType>>(json);
---- 
#Impossibility of the task with `object`
Let's imagine that that the desrialiser has the power to scan all the possible classes. Even then, it won't be able to make the right decision in many cases.
Consider this scenario.
public class A
{
    public string Name { get; set; }
    public string Color { get; set; }
}
public class B
{
    public string Name { get; set; }
    public string Color { get; set; }
    public string X { get; set; }
}
public class NodeModel
{
    public object Props { get; set; }
}
public static void Main(string[] args)
{
  var o = new NodeModel { Props = new B() { Name = "I'm B", Color = "Blue", X = null}};
  var json = serialiser.Serialise(o);
  // Json would be something like 
  // {
  //  "Props": {
  //    "Name": "I\u0027m B",
  //    "Color": "Blue",
  //  }
  // }
  //(...)
  var o2 = serialiser.Deserialise(o); 
  
  // How can the serialiser decide what to deserialise Props to?
  // Is it A or is it B?
}
