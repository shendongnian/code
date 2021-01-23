    IQueryable<Foo> theQuery; // explicitly type it 
    // var theQuery = db.Foos.AsQueryable(); // alternately infer it 
    
    if (blah)
       theQuery = db.Foos.Where(...);
    else 
       theQuery = db.Foos.OrderBy(...);
    theQuery = theQuery.Where(...); // keep chaining 
    //etc;
