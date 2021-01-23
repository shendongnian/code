    public MayBe<int> AddCategory(TCategory tCategory)
    {
        try
        {
           return this.catalogRepository.AddCategory(tCategory);
        }
        catch (Exception ex)
        {
            return MayBe<int>.CreateError(ex);
        }
        return result;
    }
    
    public MayBe<IEnumerable<TCategory>> GetCategoryHierarchy(TCategory parentCategory)
    {
        try
        {
            IEnumerable<TCategory> allCategories = catalogRepository.GetAllCategories();
            return allCategories;
        }
        catch (Exception ex)
        {
            return MayBe<int>.CreateError(ex);
        }
        return result;
    }
