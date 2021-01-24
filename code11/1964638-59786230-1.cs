C#
static class StaticClass
{
    public static void DoSomething<T>(BaseClass<T> Value)
    {
    }
}
class BaseClass<T>
{
    public T Value { get; }
    public BaseClass(T Value)
    {
      this.Value = Value;
    }
    public static implicit operator BaseClass<T>(T Value)
    {
        return new BaseClass<T>(Value);
    }
}
If you want the compiler to infer `T` when calling `StaticClass.DoSomething` you'll need to make DoSomething look like this though :
    static class StaticClass
    {
        public static void DoSomething<T>(T Value)
        {
            BaseClass<T> realValue = Value;
        }
    }
