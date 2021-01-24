public class ClassName
{
    public ClassName()
    {
        Name = string.Empty; //Default value
    }
    public ClassName(Dog dog)
    {
        Name = dog.Name;
    }
}
Or
public class ClassName
{
    public string Name { get; set; } = string.Empty;
    public ClassName() {}
    public ClassName(Dog dog)
    {
        Name = dog.Name;
    }
}
The serializer will construct a new object. The object contains a string member, and you have disabled null-able reference types. Thus you need to specify what the value will be when the object is created.
If you don't want to use the default constructor (An empty constructor), you can tell the serialiser the constructor you would like to use:
https://www.newtonsoft.com/json/help/html/JsonConstructorAttribute.htm
