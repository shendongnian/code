    [HttpGet]
    [ODataRoute]
    [EnableQuery(PageSize = 300)]
    public IQueryable<ControllingProjectReportReadModel> Get(ODataQueryOptions<ControllingProjectReportReadModel> odataQuery)
    {
        // Apply the filter as we are working on the Entity and project back to a model
        var executedQuery = _readContext.ProjectReport.Get(_mapper, odataQuery);
        return _mapper.Map<IList<ControllingProjectReportReadModel>>(executedQuery).AsQueryable();
    }
