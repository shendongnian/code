    if (User.Identity.IsAuthenticated)
    {
        var userID = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var categories = _applicationDbContext.Users.Where(p => p.Id == userID)
                            .SelectMany(p => p.ApplicationUserCategories)
                            .Select(pc => pc.Category).ToList();
    }
