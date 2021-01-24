    public async Task<IList<MyProject.Models.Campaign>> WhereAsync(System.Linq.Expressions.Expression<Func<MyProject.Models.Campaign, bool>> predicate)
        {
            try
            {
                return await db.Campaigns.Where(predicate).ToListAsync();
            }
            catch
            {
                return null;
            }
        }
