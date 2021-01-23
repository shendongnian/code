    ...
    placementCriteria.SetProjection(Projections.Id());
    residentialPlacements = session.CreateCriteria<ResidentialPlacementClientService>()
        .Add(Subqueries.In("Id", placementCriteria))
        .SetFetchMode("CaseClient.CaseFile", FetchMode.Eager);
        .SetFetchMode("CaseClient.Incomes", FetchMode.Eager); 
        .SetFetchMode("CaseClient.ClientProfile", FetchMode.Eager);
        .SetFetchMode("CaseClient.ClientProfile.Person", FetchMode.Eager);
        .SetFetchMode("VendorService", FetchMode.Eager);
        .SetFetchMode("VendorService.Vendor", FetchMode.Eager);
        .List<ResidentialPlacementClientService>();
