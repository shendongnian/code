    [HttpGet]
    public List<Object> Function1()
    {
        List<Object> result = new List<Object>();
        using (DatabaseContext db = new DatabaseContext())
        {
            //result = db.Object;
            result = (from d in db.Object.ToList()
                      select new Object{
                          prop1 = d.prop1,
                          prop2 = d.prop2,
                      .......
                }).ToList();
        // ...
        return result;
    }
}
