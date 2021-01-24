public class Location
{
   private string locationName;
   
   public Location(string name)
   {
      locationName = name;
   }
   public string Name => locationName;
}
In your case:
private static string GetAppSysDir() {
    try {
        return FileSystem.GetSubdirFromPattern(appRoaming, sysPattern);
    } catch (Exception ex) {
        // handle your exception
        // return some kind of string
    }
}
private static string appSysDir { get; } => GetAppSysDir;
  [1]: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members
