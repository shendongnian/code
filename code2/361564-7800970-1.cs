    IQueryable<ObjectType> query = getIQueryableSomehow() 
    query.Where(x => x.A); 
     
    IQueryable<ObjectType> query2 = getIQueryableSomehow() 
    query2.Where(x => x.B); 
    
    IQueryable<ObjectType> query3 = query.ToArray().AsQueryable<ObjectType>().Union(query2);
