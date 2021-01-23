    IProjection IdCount = Projections.Count("s.SpecialismId").As("IdCount");
    IQuery query = session
      .CreateCriteria<SpecialismCombo>("sc")
      .CreateCriteria("Specialism", "s");
      .Add(Expression.In("s.SpecialismId", SpecialismIds));
      .SetProjection(
        Projections.GroupProperty("sc.SpecialismComboId"),
        IdCount);
      .Add(Restrictions.Eq(IdCount, SpecialismIds.Count()));
