    Entity2 e2Alias = null;
    Entity3 e3Alias = null;
    SomeEntity s = null;
    return NHibernateHelper.Session.QueryOver<SomeEntity>()
        .JoinAlias(() => s, () => e2Alias.SomeEntityReference) //here you need to specify the other  side of the relation in the other entity that refernces th SomeEntity
        .JoinAlias(() => s, () => e3Alias.SomeEntityReference)
        .Where(() => s.Id > 10)
        .OrderBy( () => e3Alias.SortOrder).Asc //or Desc
        .List<SomeEntity>(); 
