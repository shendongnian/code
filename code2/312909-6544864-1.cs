    var subquery = QueryOver.Of(() => q)
      .SelectList(list => list.SelectGroup(() => q.ChildId))
          .Where(Restrictions.EqProperty(
              Projections.Property(() => p.Price), 
              Projections.Max(() => q.Price)))
          .And(Restrictions.EqProperty(
              Projections.Property(() => p.ChildId), 
              Projections.Property(() => q.ChildId)));
