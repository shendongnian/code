    class Food
    {
        public IList<Ingredient> ingredients;
        public Food(IList<Ingredient> ingredients)
        {
            this.ingredients = ingredients.Clone();
        }
        public bool uses(Ingredient i)
        {
            return ingredients.Contains(i);
        }
    }
    Food Cake = new Food({ Sugar, Eggs, Milk });
