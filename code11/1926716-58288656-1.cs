    var dbMock = new
    {
        PromoActivityMeasures = new[]
        {
            new { Id = 1, WorkSpaceId = 27, Organization = "Org1", MeasureCode = 4711 },
            new { Id = 2, WorkSpaceId = 28, Organization = "Org1", MeasureCode = 4711 },
            new { Id = 3, WorkSpaceId = 28, Organization = "Org2", MeasureCode = 4711 },
        }.AsQueryable(),
        PromoMeasures = new[]
        {
            new { WorkSpaceId = 28, Organization = "Org1", MeasureCode = 4711 },
        }.AsQueryable(),
    };
    var result = dbMock.PromoActivityMeasures
        .Where(pa => pa.WorkSpaceId == 28)
        .WhereNotAnyOtherThatEqualsOnCorrespondingFields(() => dbMock.PromoMeasures, "WorkSpaceId", "Organization", "MeasureCode")
        .Select(pa => pa.Id)
        .Single();
    // 3
