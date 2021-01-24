    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = new Pizza();
            string test = pizza;
        }
    }
    public class Pizza
    {
        public static implicit operator string(Pizza pizza)
        {
            return pizza.ToString();
        }
    }
