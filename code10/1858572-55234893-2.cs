        List<TvRequests> reqList = new List<TvRequests>();
        reqList.Add(new TvRequests {
            Title = "A",
            Date = DateTime.Now.AddDays(-1),
            RequestedUser = new OmbiUser
            {
                Username = "A",
                Date = DateTime.Now.AddDays(-1)
            }
        });
        reqList.Add(new TvRequests
        {
            Title = "C",
            Date = DateTime.Now.AddDays(1),
            RequestedUser = new OmbiUser
            {
                Username = "C",
                Date = DateTime.Now.AddDays(1)
            }
        });
        reqList.Add(new TvRequests
        {
            Title = "B",
            Date = DateTime.Now,
            RequestedUser = new OmbiUser
            {
                Username = "B",
                Date = DateTime.Now
            }
        });
        foreach (var item in reqList.AsQueryable().SortBy("Date", SortDirection.DESC))
            Debug.WriteLine(item.Title);
        foreach (var item in reqList.AsQueryable().SortBy("RequestedUser.Date"))
            Debug.WriteLine(item.Title);
        foreach (var item in reqList.AsQueryable().SortBy("RequestedUser.UserName",SortDirection.DESC))
            Debug.WriteLine(item.Title);
