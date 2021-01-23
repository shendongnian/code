    Image img = new Image();
    img.Path = @"https://s3.amazonaws.com/mystore/images/public/"
      + FileUpload1.PostedFile.FileName;
    
    ProductGroups_Image xref = new ProductGroups_Image();
    xref.Image = img;
    
    using (StoreDataContext db = new StoreDataContext())
    {
      ProductGroup pg = db.ProductGroups.Where(a => a.Name == txtName.Value).Single();
    
      xref.ProductGroup = pg;
    
      db.SubmitChanges();
    }
