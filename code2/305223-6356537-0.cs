    public void search(string s)
    {
        CommerceEntities db = new CommerceEntities();
         int val = Convert.ToInt32(s);
        IQueryable<Product> product = db.Products ;
            var products = from p in db.Products
                           where (p.ModelName != null && p.ModelName.Contains(s))
                           || (p.ProductID != null && p.ProductID == val)
                           || (p.ModelNumber != null && p.ModelNumber.Contains(s))
                           || (p.Description != null && p.Description.Contains(s))
                           select new
                           {
                               // Display the items 
                               ProductID = p.ProductID,
                               ProductImage = p.ProductImage,
                               UnitCost = p.UnitCost
                           };
            ListView_Products.DataSourceID = null;
            ListView_Products.DataSource = products;
    }
