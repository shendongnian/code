     string formatedDate = "";
            EventQuery query = new EventQuery();
            DateTime? time;
            if (!string.IsNullOrEmpty(startDate))
            {
                time = Convert.ToDateTime(startDate);
                formatedDate = string.Format("{0:s}", time);
                // Create the query object:
                query.Uri = new Uri("http://www.google.com/calendar/feeds/" + service.Credentials.Username + "/private/full?updated-min=" + formatedDate);
            }
            else
            {
                query.Uri = new Uri("http://www.google.com/calendar/feeds/" + service.Credentials.Username + "/private/full");
            }
            // Tell the service to query:
            EventFeed calFeed = service.Query(query);
            return calFeed.Entries.Cast<EventEntry>();
