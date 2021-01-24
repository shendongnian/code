lang-cs
private List<int> Values = new List<int>(3);
public int Value1 {
    get => Values[0];
    set => Values[0] = value;
}
public int Value2 {
    get => Values[1];
    set => Values[1] = value;
}
If you really wanted to go the reflection route... you could create an attribute to specify which properties to include when determining the max
lang-cs
[AttributeUsage(AttributeTargets.Property)]
public class IncludeInMaxAttribute : Attribute
{
}
public class MyClass {
    [IncludeInMax]
    public int Value1 {get;set;}
    [IncludeInMax]
    public int Value2 {get;set;}
    public string AnotherValue {get;set;}
    public int GetMax()
    {
        int maxValue = int.MinValue;
        foreach (var prop in this.GetType().GetProperties())
        {
            if (prop.GetCustomAttribute<IncludeInMaxAttribute>() != null)
            {
                maxValue = (int) prop.GetValue(this);
            }
        }
        return maxValue;
    }
}
