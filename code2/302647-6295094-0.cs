    var myIQueryable = my.db<SomeModel>();  // IQueryable<SomeModel>
    var countQuery = myIQueryable.Count();  // 10
    MakeAdditions(myIQueryable, 10);        // adds 10 items
    var list = myIQueryable.ToList();       // List<SomeModel> count=20
    MakeAdditions(myIQueryable, 10);
    var countList = list.Count();           // still 20, List never changed
