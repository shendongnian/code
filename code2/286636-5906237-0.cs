    public List<Requests> SearchById(int? id, DateTime? date, string name)
    {
        var cont = new Model.ModelContainer();
        var query = cont.Requests;
    
        if (id != null)
            query = query.Where(req => req.ReqId == id.Value);
    
        if (date != null)
            query = query.Where(req => req.Date == date.Value);
    
        if (!String.IsNullOrEmpty(name))
            query = query.Where(req => req.Name == name);
    
        return query.ToList();
    }
