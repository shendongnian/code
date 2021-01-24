    public IEnumerable<Quality> Get()
    {
        int g_Id = myAppPrincipal.G_Id;
        var group = UnitOfWork.GetById<Group>(g_Id);
        //in case of code-first
        var associatedGroups = group.Associations.Groups;
        var result = new List<Quality>();
        foreach(var group in associatedGroups)
        {
            var groupQualities = group.Qualities;
            // Qualities is a public virtual ICollection of Quality inside the class Group
    
           result.Add(groupQualities.Select(entity => new Quality()
           {
               Q_Id = entity.Q_Id,
               Description = entity.Description,
            ...
           }).ToList();
        }
        
    
        return result;
    }
