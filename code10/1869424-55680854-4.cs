    //...removed for brevity
    private readonly ICommonProvider commonProvider;
    
    public GlobalDataService(
        ICategoryRepository categoryRepository, 
        ISubcategoryRepository subCategoryRepository, 
        ISubcategoryDescriptionRepository subcategoryDescriptionRepository, 
        ICommonProvider commonProvider) {
        //...removed for brevity
        this.commonProvider = commonProvider;
    }
    
    public bool DoesUserRecordExist(Guid userId) {
        ICommonRepository<User> repository = commonProvider.GetRepository<User>();
        var existingData = repository.CommonDoesRecordExist(userId);
        if (existingData) {
            //do stuff
        } else {
            //do other stuff
        }
    }
    //...
