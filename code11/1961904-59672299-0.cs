    var result = Categories.Join(SubCategories, // join tables Categories and SubCategories
        category => category.Id,                // from every category take the Id,
        subCategory => subCategory.CategoryId,  // from every subCategory take foreign key CategoryId
        (category, subCategory) => new          // when they match make one new object
        {
           // we need at least Category.CategoryModel and SubCategory.SubCategoryModel
           CategoryModel = category.CategoryModel,
           SubCategoryModel = subCategory.SubCategoryModel,
           // Select other Category properties that you plan to use:
           CategoryId = category.Id,
           ...
           // Select other SubCategory properties that you plan to use:
           ...
    })
    // we don't want all combinations, only those where
    // CategoryModel is not equal to SubCategoryModel
    .Where(joinResult => joinResult.CategoryModel != joinResult.SubCategoryModel)
    // from the remaining combinations calculate the final result
    .Select(joinResult => new
    {
        Id = joinResult.CategoryId,
        Count1 = ... // sorry, don't know what property grpDetail does
        ...
    });
