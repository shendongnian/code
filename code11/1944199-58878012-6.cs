    public Manager(IFixer fixer, IProductGetter productGetter)
    {
        _fixer = fixer;
        _productGetter = productGetter;
    }
    ...
    public bool IsProductNew(int id)
    {
         var product = _productGetter.GetProduct(id);
         _fixer.Modify(product);
         return product.Name != "Default";
    }
