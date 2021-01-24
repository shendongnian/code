c#
public class A
{
    public string SomeProperty { get; set; }
    public string SomeOtherProperty { get; set; }
}
public class B
{
    public string SomeProperty { get; set; }
    public string SomeOtherProperty { get; set; }
}
And would try to do something like `(B)instanceOfA`. 
If possible, you should probably use [tuples][1] instead
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.valuetuple?view=netframework-4.8
