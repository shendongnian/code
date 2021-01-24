public class MyClass
{
    public int I1;
    public int I2;
    public int I3;
    public int I4;
}
// typeof(MyClass).GetFields() return FieldInfo[], which is IEnumerable<T>
foreach (var field in typeof(MyClass).GetFields())
{
    Console.WriteLine(field.Name);
}
// I1
// I2
// I3
// I4
However, you should probably use something else. An array might be a better fit.
  [1]: https://docs.microsoft.com/zh-cn/dotnet/api/system.reflection
