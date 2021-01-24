    // Fetch all Desserts with their Bitter ingredients
    var desertsWithoutSugar = myDbContext.Recipes
        .Where(recipe => recipy.Type == RecipyType.Dessert)
        .Select(recipe => new
        {
            // select only the properties that I plan to use:
            Id = recipe.Id,
            Name = recipe.Name,
            ...
            // not needed: you know the value: Type = recipe.Type
            
            Ingredients = recipe.Ingredients
               .Where(ingredient => ingredient.Taste == Taste.Bitter)
               .Select(ingredient => new
               {
                   // again: only the properties you plan to use
                   Id = ingredient.Id,
                   Name = ingredient.Name,
               })
               .ToList(),
         })
