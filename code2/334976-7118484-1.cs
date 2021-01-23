    public class Cat : IAnimal
    {
      public virtual string GetSound()
      {
        return "Meow!";
      }
    }
    
    public class BigCat : Cat
    {
      public override string GetSound()
      {
        return "Roar!";
      }
    }
