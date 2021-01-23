    [HttpGet]
    public JsonResult Action(int id) 
    {
       //same as above, obtain a collection
        // Load a collection with all your option's related data
        IQueryable data = LoadSomethingFromDbOrWherever(id);
        var jsonData = new
                {
                        from c in data
                        select new
                        {
                            Value= c.Value,
                            CssClass = c.CssClass,
                            Description = c.Desription
                        }).ToArray()
                };
        return Json(jsonData);
    }
