    public void AddIngredientsToVendor(VendorIngredientsRegistrationModel model)
    {
        // Ingredients, that I want to add to wendor, Ids: [57, 59, 61, 62]
        List<Ingredient> ingredients = _repository.Fetch<Ingredient>(e => model.IngredientIds.Contains(e.Id),
                   e => e.Include(p => p.VendorIngredients)).ToList();
        var vendor = _repository.First<Vendor>(
            (e => e.Id == model.VendorId),
             e => e.Include(m => m.Ingredients));
        // How to add ingredients to Vendor?
       foreach(var ingredient in ingredients)
       {
            if(vendor.Ingredients.Any(x => x.IngredientId != ingredient.Id))
            {
                vendor.Ingredients.Add(new VendorIngredient
                {
                    VendorId = vendor.Id,
                    IngredientId = ingredient.Id
                });
            }
       }
        _repository.Update(vendor);
        _repository.SaveChanges();
    }
