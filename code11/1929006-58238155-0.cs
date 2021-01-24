csharp
abstract public class Animal
{
    abstract public string GetNameAsString();
    abstract public void MakeNoise();
}
public class Cat : Animal
{
    public override string GetNameAsString() => "cat";
    public override void MakeNoise() => Console.WriteLine("meow");
}
public class Dog : Animal
{
    public override string GetNameAsString() => "dog";
    public override void MakeNoise() => Console.WriteLine("woof");
}
public class Crocodile : Animal
{
    public override string GetNameAsString() => "croc";
    // I don't want croc to make a noise, but I have to implement it anyway,
    // else the compiler will complain about the missing implementation
    public override void MakeNoise() => Console.WriteLine("what here?");
}
I may have been better off not adding `MakeNoise()` to my `Animal` class, instead I could have used composition and created a separate `IAnimalNoise` interface and used this for the dog and cat, but not the crocodile.
csharp
abstract public class Animal
{
    abstract public string GetNameAsString();
}
interface IAnimalNoise
{
    abstract public void MakeNoise();
}
public class Cat : Animal, IAnimalNoise
{
    public override string GetNameAsString() => "cat";
    public void MakeNoise() => Console.WriteLine("meow");
}
public class Dog : Animal, IAnimalNoise
{
    public override string GetNameAsString() => "dog";
    public void MakeNoise() => Console.WriteLine("woof");
}
public class Crocodile : Animal
{
    public override string GetNameAsString() => "croc";
    // Now we simply omit the interface and don't need to implement the method
}
For a better explanation or further reading, SOLID principles and Liskov substitution might be a good place to look...
