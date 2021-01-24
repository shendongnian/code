    public async Task AddRangeAsync(IEnumerable<LicenseViewModel> models, int ownerId)
    {
        var list = new List<License>();
        var owner = context.Users.Single(x => x.UserId == ownerId);
        foreach (var model in models)
        {
            list.Add(new License
            {
                ExpiryDate = model.ExpiryDate,
                Name = model.Name,
                User = owner
            });
        }
        context.Licenses.AddRange(list);
        await context.SaveChangesAsync();
    }
