    public interface IAnimal
    {
        public string Speak();
    }
    public class Dog : IAnimal
    {
        public string Speak()
        {
            return "woof!";
        }
    }
    public class Cat : IAnimal
    {
        public string Speak()
        {
            return "meow!";
        }
    }
