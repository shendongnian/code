    public interface IIngredient
    {
        int Id { get; }
        string Name { get; }
        decimal KiloPrice { get; }
    }
    public abstract class BaseIngredient:IIngredient
    {
        int Id { get; }
        string Name { get; }
        decimal KiloPrice { get; }
    }
    
    
    public class RawMaterial : BaseIngredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal KiloPrice { get; set; }
    }
    
    public class Recipe : BaseIngredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal KiloPrice => 
            RecipeLines.Sum(x => x.Ingredient.KiloPrice * x.Quantity) / 
            RecipeLines.Sum(x => x.Quantity);
        public List<RecipeLine> RecipeLines { get; set; }
    }
