C#
public interface IAnimalFeeder // the visitor
{
    void GiveFood(IAnimal animal); // main entry point
    void GiveFood(Cat cat);
    void GiveFood(Dog dog);
    void GiveFood(Fish fish);
    void GiveFood(Mouse mouse);
}
public class AnimalFeeder : IAnimalFeeder
{
    public void GiveFood(IAnimal animal)
    {
        animal.Accept(this);
    }
    public void GiveFood(Cat cat)
    {
        // ...
    }
    // etc..
}
public interface IAnimal
{
    void Accept(IAnimalFeeder feeder);
}
public class Dog : IAnimal
{
    public void Accept(IAnimalFeeder feeder)   // same code for each implementation of IAnimal
    {
        feeder.GiveFood(this);
    }
}
  [1]: https://en.wikipedia.org/wiki/Visitor_pattern
