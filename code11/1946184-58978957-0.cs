     GraphServiceClient graphClient = new GraphServiceClient(AuthProvider);
            DateTime d = DateTime.UtcNow; //DateTime.Now.ToLocalTime();
            //d = DateTime.Parse("11/20/2019 08:14:34 PM"); //for debug only
            DateTime.SpecifyKind(d, DateTimeKind.Unspecified).ToString("o");
            string MicrosoftDateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffff";
            var start = d.ToString(MicrosoftDateTimeFormat);
            var end = d.ToString("yyyy'-'MM'-'dd'T'23:59:59.9");            //"2019-07-24T23:00:00.0";//
            
            //start = "2019-11-20T10:00:00.0000000"; //for debug only
            //end = "2019-11-20T23:59:59.0000000";   //for debug only
            //var link = $"https://graph.microsoft.com/v1.0/me/calendarview?startdatetime={start}&enddatetime={end}&orderby=start/dateTime";  //not used. was previously used for http call; before moving to sdk.
            List<Option> options = new List<Option>
            {
                new QueryOption("startDateTime", start),
                new QueryOption("endDateTime", end),
                new QueryOption("orderby", "start/dateTime")
            };
            var events = await graphClient.Me.CalendarView
            .Request(options)
            //.Header("Prefer", "outlook.timezone=\"" + TimeZoneInfo.Local.Id + "\"")            
            .Select(e => new
            {
                e.Subject,
                e.Body,
                e.BodyPreview,
                e.Organizer,
                e.Attendees,
                e.Start,
                e.End,
                e.Location
            })            
            .GetAsync();
