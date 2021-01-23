    GAuthSubRequestFactory authFactory = 
        new GAuthSubRequestFactory("cl", "TesterApp");
    authFactory.Token = (String) Session["token"];
    CalendarService service = new CalendarService(authFactory.ApplicationName);
    service.RequestFactory = authFactory;
    EventQuery query = new EventQuery();
    query.Uri = new Uri("http://www.google.com/calendar/feeds/default/private/full");
    EventFeed calFeed = service.Query(query);
    foreach (Google.GData.Calendar.EventEntry entry in calFeed.Entries)
    {
        //...
    }
