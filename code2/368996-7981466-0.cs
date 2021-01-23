    Session
    .CreateCriteria<Table>()
    .Add(Restrictions.Or(
        Restrictions.And(
            Restrictions.Eq("Field1", 1),
            Restrictions.Eq("Field2", 1)),
        Restrictions.Eq("Field3", 1))
    .List<Table>();
