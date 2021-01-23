    public void outputData(object theEvent)
    {
        var event = (Event)theEvent;
        MainContainerDiv.InnerHtml = event.ID;
        //
        // You can now use "event" as a strongly typed Event object for any further
        // required lines of code
    }
