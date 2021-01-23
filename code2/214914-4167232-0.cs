    public interface IAnimal
    {
       string GetDescription();
    }
    class Cat : IAnimal
    {     
       public string GetDescription()
       {
          return "I'm a cat";
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
           Cat myCat = new Cat();
           Console.WriteLine(myCat.GetDescription());
        }
    }
