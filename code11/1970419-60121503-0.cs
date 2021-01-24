    Blog bAlias = null;
    Tag tAlias = null;
    var blogs = session.QueryOver<Blog>(() => bAlias)
      .JoinAlias(() => bAlias.Tags, () => tAlias)
      .WhereRestrictionOn(_ => tAlias.Name).IsLike("%name%") // condition 3
      .Where(Restrictions.Disjunction()
         .Add(Restrictions.On<Blog>(_ => bAlias.Name).IsLike("%name%")) // condition 1
         .Add(Restrictions.On<Tag>(_ => tAlias.Name).IsLike("%name%")) // condition 2
      )
      .List<Blog>();
