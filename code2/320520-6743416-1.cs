    var q = _someCollection.Where(c => c.Id == 100).Select(new ContryInfo { Id = c.Id, Name = c.Name}).
    
    Session["a"] = q.ToList();
    
    var list = (IList<ContryInfo>)Session["a"];
