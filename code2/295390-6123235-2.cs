    var addressQuery = DetachedCriteria.For<Address>()
        .Add(Restrictions.Like("AddressName", "%string%"))
        .SetProjection(Projections.Property("Company.CompanyId"));
    
    var companies = session.CreateCriteria<Company>()
        .Add(Subqueries.PropertyIn("CompanyId", addressQuery))
        List<Company>();
