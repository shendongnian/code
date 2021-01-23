    var _productService = EngineContext.Current.Resolve<IProductService>();
    if (Model.SubCategories.Count > 0)
    {
    foreach (var SubCategories in Model.SubCategories)
    {
     int subcategoryid = SubCategories.Id;<br>
     IPagedList<Product> _products = _productService.SearchProducts(subcategoryid,0, null, null, null, 0, string.Empty, false, 0,null,ProductSortingEnum.Position, 0, 4);
    }
    i++
    }
