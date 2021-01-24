csharp
public class Animal
{
    public virtual void Print() { }
}
public class Cat : Animal
{
    public override void Print() { Console.WriteLine("Meow"); }
}
This is not supported:
csharp
public class Animal
{
    protected virtual void Print() { }
}
public class Cat : Animal
{
    public override void Print() { Console.WriteLine("Meow"); } // Base is protected, so this doesn't make sense.
}
