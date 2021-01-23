    var brandProjections = this.session.CreateCriteria<Brand>()
        .SetProjection(Projections.ProjectionList()
            .Add(Projections.Property("Name"), "Name")
            .Add(Projections.Property("Identity"), "Identity"))
        .SetResultTransformer(Transformers.AliasToBean<NameIdentityPair>())
        .List<NameIdentityPair>();
    foreach (var brandProjection in brandProjections)
    {
        Console.WriteLine(
            "Identity: {0}, Name: {1}", 
            brandProjection.Identity, 
            brandProjection.Name);
    }
