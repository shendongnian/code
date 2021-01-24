    public void MoveMainEntityCodesToSubEntity(MainEntity mainEntity, SubEntity subEntity)
    {
        var mainEntityClasses = _mainEntityClassRetriever.GetBymainEntityId(mainEntity.id);
        subEntity.subEntityClasses = new List<SubEntityClass>();
    
        foreach (var mainEntityClass in mainEntityClasses)
        {
            var subEntityClass = new subEntityClass
            {
                CreatedDate = DateTime.Now,
                ValueRefId = mainEntityClass.ValueRefId
            };
    
            subEntity.subEntityClasses.Add(subEntityClass);
        }       
    }
