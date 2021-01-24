public static class Info
{
    public static string MethodName([System.Runtime.CompilerServices.CallerMemberName] string name = "")
    {
        return name;
    }
}
