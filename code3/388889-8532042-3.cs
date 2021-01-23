    Tree treeAlias = null;
    var nonRottenApples = QueryOver.Of<Apple>()
        .Where(a => !a.IsRotten)
        .Where(a => a.Tree.Id == treeAlias.Id)
        .Select(x => x.Id);   <- optional
    return NHibernateSession.QueryOver(() => treeAlias)
        .Where(t => t.Id.IsIn(ListOfTreeId))
        .WithSubquery.WhereExists(nonRottenApples)
        .List();
