    [WebGet(ResponseFormat = WebMessageFormat.Json)]
    public IQueryable<GetMyListEF> GetMyList()
    {
        return this.CurrentDataSource.GetMyListEF();
    }
 
