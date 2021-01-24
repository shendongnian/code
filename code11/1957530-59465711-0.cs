C#
    public IEnumerable<int> ExtractSubcategories(int categoryId)
    {
        var categories = new List<int> {categoryId};
        var subCategories = new List<int>();
        while (categories.Count > 0)
        {
            // categories will store the categories to check
            int cat = categories[0];
            categories.RemoveAt(0);
            // checking the mapped categories
            var mapped = categoriesMapping.Where(x => x.CatID == cat)
                                          .Select(x => x.MapCatID)
                                          .ToList();
            if (mapped.Count > 0) 
            {
                // there are mapped categories,
                // thus we look for their children
                categories.AddRange(mapped);
            }
            else 
            {
                // there are no mapped categories,
                // this category is a child, we add it to the result
                subCategories.Add(cat);
            }
        }
        return subCategories;
    }
    [Test]
    public void Test() => 
        CollectionAssert.AreEquivalent(ExtractSubcategories(2), new[] {4, 12, 13, 14});
