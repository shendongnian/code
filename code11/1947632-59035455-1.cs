    public void AddIngredientsToVendor(VendorIngredientsRegistrationModel model)
    {
        // Ingredients, that I want to add to wendor, Ids: [57, 59, 61, 62]
        List<Ingredient> ingredients = _repository.Fetch<Ingredient>(e => model.IngredientIds.Contains(e.Id),
                   e => e.Include(p => p.VendorIngredients)).ToList();
        vendor.Ingredients = ingredients;
        _repository.Update(vendor);
        _repository.SaveChanges();
    }
