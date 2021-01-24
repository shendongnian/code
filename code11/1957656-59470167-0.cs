csharp
private static void Main(string[] args)
{
  ...
}
Your program should therefore look like this:
csharp
using System;
namespace Normal
{
  public class Program
  {
    private static void Main(string[] args)
    {
      Exercise1();
      Exercise2();
    }
    public static void Excercise1()
    {
    }
    public static void Excercise2()
    {
    }
  }
}
Without the `Main` static method, the C# compiler wouldn't know where your program's start point is. 
There are, of course, cases where you don't need an entry point to your program. When you're developing a library (a DLL), it's not meant to run by itself, but other code is going to call its methods. In this case, though, I think you're aiming for a program with an actual entry point.
