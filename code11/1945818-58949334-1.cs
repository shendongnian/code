    public override async void OnNavigatedTo(INavigationParameters parameters)
    {
        var activity = parameters["activity"] as ActivityModel;
        Activity = activity ?? new ActivityModel();
        await FetchCategories(); 
        await FetchActivityDetail();
    }
