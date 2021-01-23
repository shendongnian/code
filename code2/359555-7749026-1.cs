    Entities context = new Entities();
    context.tbl.Where(t=>t.Id == someId)
        .Select(t=> new() {
            t.Id, 
            context.tbl2.First(tbl2=>tbl2.Id == t.Id).Value, //This is the subquery
            t.whatever});
