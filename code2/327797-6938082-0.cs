    IQuery query = session.CreateCriteria<SpecialismCombo>("sc")
    
    int counter = 0;
    foreach(int id in ids)
    {
      string alias = "s" + counter++;
      query
        .CreateCriteria("Specialism", alias);
        .Add(Expression.Eq(alias + ".SpecialismId", id));
    }
