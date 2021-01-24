csharp
using System;
public interface IState
{
    string Name => "Unknown";
}
public class Demo : IState
{
    public void PrintName()
    {
        Console.WriteLine(((IState) this).Name);
    }
}
class Program
{
    static void Main()
    {
        new Demo().PrintName();
    }
}
