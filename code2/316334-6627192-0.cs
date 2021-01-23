    var dc = new MyDataContext(); // wrap with using block in production
    var query = dc.MyTable.AsQueryable();
    
    if(filter1)
      query = query.Where(i=>i.Name.Contains(text));
    
    if(filter2)
      query = query.Where(i=>i.Age == age);
