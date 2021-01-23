    using (TransactionScope scope = new TransactionScope())
    {
    myDataContext db = new myDataContext();
    
    Process openProcess = new Process();
    
    openProcess.Creation = DateTime.Now;
    openProcess.Number = pNumber;
    
    
    
    db.Process.InsertOnSubmit(openProcess);
    db.SubmitChanges();
    //openProcess.Id will be populated
    Product product = new Product();
    
    product.Code = pCode;
    product.Name = pName;
    product.Process_Id = openProcess.Id;    
    db.Products.InsertOnSubmit(product); // I assume you missed this step in your example
    db.SubmitChanges();
    
    scope.Complete()
    }
