public class SomeClass {
    public static void CallMe() {
        Console.WriteLine("Hello!");
    }
    
    public Action GetCallMe() { 
        return CallMe;
    }
}
...
private void Main(string[] args) {
    var classInstance = new SomeClass();
    Action a = classInstance.GetCallMe();
    a();
}
[System.Action Docs][1]
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.action?view=netframework-4.8
