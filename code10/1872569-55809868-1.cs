    public void MoveMainEntityCodes(MainEntity source, MainEntity target)
    {
        // if lazy loading is enabled...
        var subEntities = new List<SubEntity>(source.SubEntityClasses);
        // or if lazy loading is disabled and you don't know if the sub entities were loaded.
        //if(source.SubEntityClasses == null || !source.SubEntityClasses.Any())
        //    _context.Entity(source).Collection(x => x.SubEntityClasses).Load();
        //var subEntities = new List<SubEntity>(source.SubEntityClasses);
    
        foreach(var subEntity in subEntities)
        {
           source.SubEntityClasses.Remove(subEntity);
           target.SubEntityClasses.Add(subEntity);
           subEntity.CreatedDate = DateTime.Now; // if you want to refresh the created date.
        }
    }
