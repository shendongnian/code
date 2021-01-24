public class ClassName
{
    public ClassName()
    {
        Name = string.Empty; //Default value
    }
}
Or
public class ClassName
{
    public string Name { get; set; } = string.Empty;
    public ClassName() {}
}
The serializer will construct a new object. The object contains a string member, and you have disabled null-able reference types. Thus you need to specify what the value will be when the object is created.
