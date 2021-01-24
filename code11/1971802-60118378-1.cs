public partial class MyClass
{
#if DEBUG
    public string SaySoemthing()
    {
        return "Something!";
    }
#endif 
}
Then the `SaySomething` method will be just available in debug mode.
