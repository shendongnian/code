public class ThirdParty
{
    public string MethodA(string arg1 = "defaultArg1", string arg2 = "defaultArg2",
        string arg3 = "defaultArg3")
    {
        return $"{arg1}, {arg2}, {arg3}";
    }
}
And we can use our reflection method to call it with as many named parameters as we like. Below I'm just giving a value for the second parameter:
    public static void Main(string[] args)
    {
        var namedParameters = new Dictionary<string, object>
        {
            {"arg2", "custom Arg 2 value"}
        };
        var instance = new ThirdParty();
        var result = InvokeWithOrderedParameters(instance, "MethodA", namedParameters);
        Console.WriteLine(result.ToString());
        GetKeyFromUser("\nDone! Press any key to exit...");
    }
**Output**
As you can see, the value we specified was passed, and the default values were used where we didn't specify anything:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/qrw61.png
