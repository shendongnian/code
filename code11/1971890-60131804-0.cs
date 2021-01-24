csharp
using System;
class MainClass {
  public static void Main (string[] args) {
    Action throwException = null;
    try {
      Console.WriteLine("Defining delegate");
      throwException = () => {
        Console.WriteLine("Throwing exception");
        throw new Exception();
      };
    } catch (Exception) {
      Console.WriteLine("Exception caught at point 1");
    }
    try {
      Console.WriteLine("Invoking delegate");
      throwException.Invoke();
    } catch (Exception) {
      Console.WriteLine ("Exception caught at point 2");
    }
  }
}
Output:
Defining delegate
Invoking delegate
Throwing exception
Exception caught at point 2
