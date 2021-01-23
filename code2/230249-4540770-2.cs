    List<Parent> result = 
    (
    from p in Parents
    where !p.Gender
    select new Parent()
    {
      Gender = p.Gender,
      Children = 
      (
        from c in p.Children
        where !c.Gender
        select new Child()
        {
          Gender = c.Gender,
          GrandChildren =
          (
            from gc in c.GrandChildren
            where !gc.Gender
            select new GrandChild()
            {
              Gender = gc.Gender
            }
          ).ToList()
        }
      ).ToList()
    }).ToList();
