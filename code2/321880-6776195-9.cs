    List results = session.CreateCriteria<BrandTable>()
    .SetProjection( Projections.ProjectionList()
         .Add( Projections.Id(), "Id" )
         .Add( Projections.Property("Name"), "Name" )
    )
    .SetResultTransformer(Transformers.AliasToBean<BrandTable>()); // edit - don't forget the result transformer! 
    .List();
