    public void Delete(PackageProduct packageProduct)
    {
        var x = _entities;
        if (x == null)
        {
            throw new Exception("_entities was null");
        }
        var y = x.PackageProducts;
        if (y == null)
        {
            throw new Exception("_entities.PackageProducts was null");
        }
        y.DeleteObject(packageProduct);
    }
