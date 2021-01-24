class MainClass 
{
    public static void Main (string[] args) {
       return PizzaTotal("Cheese"); // Place it here. before the curly braces
       // OR Print It.
       Console.WriteLine(PizzaTotal("Cheese"));
       Console.ReadLine();
    }
    static int PizzaTotal(string pizzaType)
    {
        Dictionary<string, int> PizzaCost = new Dictionary<string, int>()
            {
                { "Cheese", 10 },
                { "Pepperoni", 11 },
                { "Vegetarian", 12 },
            };
        return PizzaCost[pizzaType];
    }
}
