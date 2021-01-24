public class PizzaSet
{
    [Flags]
    public enum Toppings { GreenOlives = 1, BulgarianCheese = 2, Onions = 4, Mushrooms = 8, Peppers = 16, Basil = 32, Sausage = 64, Pepperoni = 128, Ham = 256, Beef = 512 }
    [Flags]
    public enum Sauces { BBQ = 1, Islands = 2 }
    public enum Size { Personal, Medium, Family }
    public Size PizzaSize { get; set; }
    public Sauces PizzaSauces { get; set; }
    public Toppings PizzaToppings { get; set; }
}
Then `Toppings` and `Sauces` become a bit field of possible values (notice the values will need to represent unique bits)
To select multiple toppings:-
PizzaSet ps = new PizzaSet();
ps.Toppings = Toppings.GreenOlives | Toppings.Peppers;
However, given your list of toppings and sauces may change over time, it's probably better to have a separate table that lists toppings, and use a join table (since it's EF Core)
