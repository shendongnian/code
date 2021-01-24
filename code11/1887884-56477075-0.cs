    private void subscribe()
    {
        ParseQuery<ParseObject> liveQuery = new ParseQuery<ParseObject>("Object").WhereEqualTo("u", u);
    
        subscription = liveQueryClient.Subscribe<ParseObject>(liveQuery).HandleEvent(Parse.LiveQuery.Subscription.Event.Create, new Parse.LiveQuery.Subscription.EventCallback<ParseObject>(parseLiveQueryCallback));
    }  
    private void parseLiveQueryCallback(ParseQuery<ParseObject> q, ParseObject o)
    {
        //Actions here
    }
