    public IEnumerable<Category> GetSubCategoriesFor(int catId)
    {
        var subs = db.Categories.Where(c => c.ParentId == catId);
        foreach (var sub in subs)
        {
            yield return sub;
 
            // Recursive call
            foreach (var subsub in GetSubCategoriesFor(sub.Id))
            {
                yield return subsub;
            }
        }
    }
