    void Main()
    {
    
    	Test<AnimalList<Animal>> t = new Test<CatList>();
    	t.List.Add(new Cat());
    	//You just dogged a cat!
    	t.List.Add(new Dog());
        //Change your t to something like:
        Test<AnimalList<Animal>> t = new Test<AnimalList<Animal>>();
    	t.List.Add(new Cat());
    	//You just dogged an *animal* that's perfectly ok!
    	t.List.Add(new Dog());
    }
    
    public class Test<TAnimalList> where TAnimalList : AnimalList<Animal>
    {
    	public TAnimalList List { get; set; }
    }
    
    public class CatList : AnimalList<Cat> {}
    public class DogList : AnimalList<Dog> {}
    
    public class AnimalList<TAnimal> : List<TAnimal> where TAnimal : Animal
    {
    } 
    
    public class Cat : Animal 
    {
    	public override void Speak() { "Meow".Dump(); }
    }
    public class Dog : Animal
    {
    	public override void Speak() { "Woof".Dump(); }
    }
    
    public abstract class Animal 
    {
    	public abstract void Speak();
    }
