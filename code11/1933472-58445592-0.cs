    //private void MapPropertiesOfEntityToResult(EntityClass entity
    //   , ResultDto resultAlias, IQueryOver<EntityClass, EntityClass> query)
    private void MapPropertiesOfEntityToResult( // no need for entity
          ResultDto resultAlias, IQueryOver<EntityClass, EntityClass> query)
    {
      query.SelectList(list => list
       //.Select(() => entity.PrimaryID).WithAlias(() => resultAlias.PrimaryID)
       //.Select(() => entity.SecondaryID).WithAlias(() => resultAlias.SecondaryID)
       .Select(entity => entity.PrimaryID).WithAlias(() => resultAlias.PrimaryID)
       .Select(entity => entity.SecondaryID).WithAlias(() => resultAlias.SecondaryID)
        );
    }
