using System;
public class Dog
{
	public Dog(string name)
	{
		this.Name = name;
	}
	public string Name;
	public Breed Breed;
}
public class Breed
{
	public Breed(string name)
	{
		Name = name;
	}
	public string Name;
}
public class Program
{
	public static void Main()
	{
		Dog dog = new Dog("Bowser");
		dog.Breed = new Breed("Pug");
        WeakReference dogRef = new WeakReference(dog);
        WeakReference breedRef = new WeakReference(dog.Breed);
        Console.WriteLine(dogRef.IsAlive);
        Console.WriteLine(breedRef.IsAlive);
		dog.Breed = null;
		GC.Collect();
        Console.WriteLine(breedRef.IsAlive);
        dog = null;
        GC.Collect();
        Console.WriteLine(dogRef.IsAlive);
	}
}
###Output:###
true
true
false
false
