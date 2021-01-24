    public IEnumerable<RelatedEntity> LoadRelated()
    {
        using (var context = new MyDbContext())
        {
            return context.RelatedEntities.ToList();
        }
    }
    
    public void SaveEntity(ParentEntity entity)
    {
        using (var context = new MyDbContext())
        {
            context.ParentEntities.Add(entity);
            context.SaveChanges()
        }
    }
    
    public void SomeAction(ParentEntityViewModel viewModel)
    {
        var relatedEntities = LoadRelated();
        var relatedEntity = relatedEntities
            .OrderBy(x => x.ApplicableDate)
            .First(x => x.ApplicableDate >= DateTime.Now);
        var newEntity = new ParentEntity
        {
            Name = viewModel.Name,
            RelatedEntity = relatedEntity
         };
         SaveEntity(newEntity);
    }
