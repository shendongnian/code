    myDataContext db = new myDataContext();
    
    Process openProcess = new Process();
    
    openProcess.Creation = DateTime.Now;
    openProcess.Number = pNumber;
    
    Product product = new Product();
    
    product.Code = pCode;
    product.Name = pName;
    product.Process = openProcess;
    
    db.Product.InsertOnSubmit(product);
    db.SubmitChanges();
