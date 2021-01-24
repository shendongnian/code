    public class RecipeLine
    {
        public int Id { get; set; }
        private readonly BaseIngredient _ingredient;
        public IIngredient Ingredient=>_ingredient;
        public decimal Quantity { get; set; }
    }
