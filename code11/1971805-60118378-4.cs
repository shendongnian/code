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
If you would like to put all these code in a different library, you car create a class library and put the extension classes in global namespace (no namespace) and then add a conditional reference:
    <ItemGroup Condition=" '$(Configuration)' == 'Debug' ">
      <Reference Include="GlobalExtensions">
        <HintPath>..\Somewhere\GlobalExtensions.dll</HintPath>
      </Reference>
    </ItemGroup>
