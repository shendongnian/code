    public abstract class Food
    {
      public static IList<Ingredient> ingredients
      public bool uses(Ingredient i)
      {
        return GetIngredients().Contains(i);
      }
      protected abstract IList<Ingredient> GetIngredients();
    }
    public class Cake : public Food
    {
      public static IList<Ingredient> ingredients = new List<Ingredient>()
      {
        Sugar,
        Eggs,
        Milk
      }
       protected override IList<Ingredient> GetIngredients()
       {
          return ingredients ;
       }
    }
