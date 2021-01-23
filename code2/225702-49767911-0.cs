    public abstract class Fruit
    {
        public abstract string GetColor();
    }
    public class Orange : Fruit
    {
        public override string GetColor()
        {
            return "Orange Color";
        }
    }
    public class Apple : Fruit
    {
        public override string GetColor()
        {
            return "Red color";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Fruit fruit = new Orange();
            Console.WriteLine(fruit.GetColor());
            fruit = new Apple();
            Console.WriteLine(fruit.GetColor());
        }
    }
