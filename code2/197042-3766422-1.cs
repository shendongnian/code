    using(MyDataContext db = new MyDataContext())
    {
        // get the record
        Product dbProduct = db.Products.Single(p => p.ID == 1);
        // set new values
        dbProduct.Quantity = 5;
        dbProduct.IsAvailable = false;
        // save them back to the database
        db.SubmitChanges();
    }
