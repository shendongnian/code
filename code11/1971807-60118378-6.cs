public partial class MyClass
{
#if DEBUG
    public string SaySomething()
    {
        return "Something!";
    }
#endif 
}
For types which doesn't belong to you , you can use extension methods like this (You can also use this solution for the types which belongs to you):
public static class SqlCommandExtensions
{
#if DEBUG
    public static string SaySomething(this SqlCommand command)
    {
        return "Something!";
    }
#endif
}
**You can use Conditional Reference**
If you would like to put all these code in a different library, you car create a class library and put the extension classes in global namespace (no namespace) and then add a conditional reference:
    <ItemGroup Condition=" '$(Configuration)' == 'Debug' ">
      <Reference Include="GlobalExtensions">
        <HintPath>..\Somewhere\GlobalExtensions.dll</HintPath>
      </Reference>
    </ItemGroup>
In this solution, you don't need if debug.
public static class SqlCommandExtensions
{
    public static string SaySomething(this SqlCommand command)
    {
        return "Something!";
    }
}
**Use Assembly.Load in Immediate Window**
As another option, you can create another assembly and then put these extension methods in global namespace (no namespace) in that assembly. Then without adding reference, and just at debug time, in the immediate window you can use them:
    Assembly.LoadFile(@"C:\Somewhere\GlobalExtensions.dll")
    yourSqlCommand.SaySomething()
In this solution, you don't need if debug, you also don't need any add reference and it's only available at debug time and immediate window:
 
public static class SqlCommandExtensions
{
    public static string SaySomething(this SqlCommand command)
    {
        return "Something!";
    }
}
