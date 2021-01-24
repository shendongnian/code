    public IEnumerable<Quality> Get()
    {
        int g_Id = myAppPrincipal.G_Id;
        var group = UnitOfWork.GetById<Group>(g_Id);
        //in case of code-first
        var associatedGroups = group.Assoc_Group.Groups;
        var qualities = new List<Quality>();
        foreach (var assoc in associatedGroups.Select(t => t.Association).Distinct())
        {
            qualities.AddRange(assoc.Assoc_Groups.SelectMany(t => t.group.Qualities).ToList());
        }
        
        var result = qualities.Distinct();
        return result;
    }
