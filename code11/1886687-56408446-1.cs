    public void Configure(IApplicationBuilder app, IDatabaseChangeNotificationService dbService)
    {
        dbService.Config();
        //snip
    }
