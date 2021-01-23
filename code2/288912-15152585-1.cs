    Google.GData.Calendar.EventEntry Entry = new Google.GData.Calendar.EventEntry();
    //create the ExtendedProperty and add the EventID in the new event object, 
    //so it can be deleted / updated later
    ExtendedProperty oExtendedProperty = new ExtendedProperty();
    oExtendedProperty.Name = "EventID";
    oExtendedProperty.Value = GoogleAppointmentObj.EventID;
    Entry.ExtensionElements.Add(oExtendedProperty);
    
    string ThisFeedUri = "http://www.google.com/calendar/feeds/" + CalendarID 
    + "/private/full";
    Uri postUri = new Uri(ThisFeedUri);
    
    //create an event query object and attach the EventID to it in Extraparameters
    EventQuery Query = new EventQuery(ThisFeedUri);
    Query.ExtraParameters = "extq=[EventID:" + GoogleAppointmentObj.EventID + "]";
    Query.Uri = postUri;
    
    //Find the event with the specific ID
    EventFeed calFeed = CalService.Query(Query);
    //if search contains result then delete
    if (calFeed != null && calFeed.Entries.Count > 0)
    {
       foreach (EventEntry SearchedEntry in calFeed.Entries)
       {
          SearchedEntry.Delete();
          break;
       }
       
    }
