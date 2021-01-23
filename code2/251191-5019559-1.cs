    public void outputData(object theEvent)
    {
        if (theEvent is Event)
        {
            MainContainerDiv.InnerHtml = (theEvent as Evenet).ID;
        }
        // process others as necessary
    }
