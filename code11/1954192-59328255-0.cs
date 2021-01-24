csharp
public class Animal
{
    public virtual void Print() { }
}
public class Cat : Animal
{
    public virtual void Print() { Console.WriteLine("Meow"); }
}
