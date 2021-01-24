    UsernamePasswordProvider authProvider = new UsernamePasswordProvider(publicClientApplication, scopes);
                GraphServiceClient graphClient = new GraphServiceClient(authProvider);
                User me = graphClient.Me.Request()
                    .WithUsernamePassword("username.onmicrosoft.com", s)
                    .GetAsync().Result;
                var queryOptions = new List<QueryOption>()
                {
                    new QueryOption("startDateTime", "2020-02-12T16:00:00.0000000"),
                    new QueryOption("endDateTime", "2020-02-18T16:00:00.0000000")
                };
    
                var calendarView = graphClient.Me.Calendar.CalendarView
                    .Request(queryOptions)
                    .GetAsync().Result;
