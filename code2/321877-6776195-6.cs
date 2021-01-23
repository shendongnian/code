    List results = session.CreateCriteria<BrandTable>()
    .SetProjection( Projections.ProjectionList()
         .Add( Projections.Property("id"), "Id" )
         .Add( Projections.Property("Name"), "Name" )
    )
    .List();
