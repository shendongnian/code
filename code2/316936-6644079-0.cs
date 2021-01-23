    public ProductContent()
    {
        productxEntities db = new productxEntities();
        ProductTypes = db.ProductCodes.ToList().Select(c => new SelectListItem
        {
            Value = c.product_type.ToString(),
            Text = c.code.ToString()
        });
    }
