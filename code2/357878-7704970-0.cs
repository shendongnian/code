    public class IngredientStore
    {
        public static IngredientStore Current
        {
            get;
            private set;
        }
    
        private Dictionary<Type, List<Ingredient>> ingredients = new Dictionary<Type, List<Ingredient>>();
    
        static IngredientStore()
        {
            Current = new IngredientStore();
        }
    
        public void Register(Type type, List<Ingredient> ingredients)
        {
            this.ingredients[type] = ingredients;
        }
    
        public bool Uses(Type type, Ingredient ingredient)
        {
            // TODO: check the type is registered
            return this.ingredients[type].Contains(ingredient);
        }
    }
    
    public class Food
    {
        public bool Uses(Ingredient ingredient)
        {
            return IngredientStore.Current.Uses(this.GetType(), ingredient);
        }
    }
    
    public class Cake : Food
    {
        static Cake()
        {
            IngredientStore.Register(typeof(Cake), new List<Ingredient>
            {
                Ingredient.Butter,
                Ingredient.Eggs,
                Ingredient.Flour,
            };
        }
    }
    
    public class CherryCake : Cake
    {
        static CherryCake()
        {
            IngredientStore.Register(typeof(CherryCake), new List<Ingredient>
            {
                Ingredient.Butter,
                Ingredient.Eggs,
                Ingredient.Flour,
                Ingredient.Cherries,
            };
        }
    }
