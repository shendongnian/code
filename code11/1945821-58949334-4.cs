    public override async void OnNavigatedTo(INavigationParameters parameters)
    {
        try
        {
            var activity = parameters["activity"] as ActivityModel;
            Activity = activity ?? new ActivityModel();
            await FetchCategories(); 
            await FetchActivityDetail();
         }
         catch(Exception ex)
         {
             // log or tell the user
         }
    }
