    interface Cat
    {
        string Name {get;}
    }
    interface Dog
    {
        string Name{get;}
    }
    public class Animal : Cat, Dog
    {
        string Cat.Name
        {
            get
            {
                return "Cat";
            }
        }
        string Dog.Name
        {
            get
            {
                return "Dog";
            }
        }
    }
    static void Main(string[] args)
    {
        Animal animal = new Animal();
        Cat cat = animal; //Note the use of the same instance of Animal. All we are doing is picking which interface implementation we want to use.
        Dog dog = animal;
        Console.WriteLine(cat.Name); //Prints Cat
        Console.WriteLine(dog.Name); //Prints Dog
    }
