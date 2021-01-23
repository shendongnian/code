Task task = Task.Factory.StartNew(SomeMethod);
Console.WriteLine(task.Result);
public static string SomeMethod()
{
    return "Hello World";
}
