    var criteria = DetachedCriteria.For<Company>()
       .CreateCriteria("this.Addresses", "a")
       .SetFetchMode("a", FetchMode.Join)
       .Add(Restrictions.InsensitiveLike("a.Address", <string variable>, MatchMode.Anywhere))
       .SetResultTransformer(new DistinctRootEntityTransformer());
