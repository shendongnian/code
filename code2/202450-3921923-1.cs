    using CompanyCatalogue; //my web reference
    ...
    protected void Page_Load(object sender, EventArgs e)
    {
        CompanyCatalogueEntities dataContext = new CompanyCatalogueEntities(); 
        DataServiceQuery<GetItemsResult> q = dataContext.CreateQuery<GetItemsResult>("GetItems")
            .AddQueryOption("paramName", 6)
            .AddQueryOption("paramName2", 20.5);
        List<GetItemsResult> items = q.Execute().ToList();
    }
