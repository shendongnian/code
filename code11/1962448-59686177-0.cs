    public async Task<Guid> Save(Entities.BuyGroup model)
    {
        using (var dc = _dataContext())
        {
            var existing = await Get(model.Id); 
            if (existing != null)
            {
                dc.ByGroups.Entry(model).State = EntityState.Modified;
            } else {
                await dc.BuyGroups.AddAsync(model);
            }
            await dc.SaveChangesAsync();
        }
    }
