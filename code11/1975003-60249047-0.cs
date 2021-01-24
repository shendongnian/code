     public async Task<User> GetUserWithRecipes(int id)
        {
            var userWithRecipes = await _context.Users.
            Include(r => r.Recipes)
            .FirstOrDefaultAsync(r => r.Id == id);
            return userWithRecipes;
        }
