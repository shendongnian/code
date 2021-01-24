    var recipe = context.Recipes
        .Select(x => new RecipeViewModel
        {
            Id = x.Id,
            Name = x.Name,
            RelatedRecipes = x.RelatedRecipes
                 .Where(r => r.IsActive)
                 .Select(r => new RecipeViewModel
                 {
                     Id = r.Id,
                     Name = r.Name
                 }).ToList()
        }).Single(x => x.Id == recipeId);
