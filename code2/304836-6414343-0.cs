    var result = CreateCriteria<User>()
        .CreateAlias("CompanyRole", "cr")
        .SetProjection(Projections.ProjectionList()
            .Add(Projections.Property("FirstName"))
            .Add(Projections.Property("LastName"))
            .Add(Projections.Property("cr.Role"))
            )
        .List<object[]>();
    foreach (var item in result)
    {
        string name = string.Concat(item[0], item[1]);
        Role role = (Role)item[2];
        // do something with name and role
    }
