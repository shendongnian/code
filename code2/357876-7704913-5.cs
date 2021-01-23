    public class Cake : Food
    {
      public override IList<Ingredient> Ingredients
      {
          get { 
                  return new IList<Ingredient>()
                  { Sugar, Eggs, Milk };
              }
      }
    }
