    /// <summary>
    /// Registered callback function for recieving object events
    /// </summary>
    /// <param name="inEvent">Indicate the event type supplemented.</param>
    /// <param name="inRef">Returns a reference to objects created by the event.</param>
    /// <param name="inContext">Passes inContext without modification</param>
    /// <returns>Status 0 (OK)</returns>
    private uint objectEventHandler(uint inEvent, IntPtr inRef, IntPtr inContext)
    {
        switch (inEvent)
        {
            case EDSDK.ObjectEvent_DirItemCreated:
                 this.invokeNewItemCreatedEvent(new NewItemCreatedEventArgs(getCapturedItem(inRef)));
                 Console.WriteLine("Directory Item Created");
                 break;
            case EDSDK.ObjectEvent_DirItemRequestTransfer:
                 Console.WriteLine("Directory Item Requested Transfer");
                 break;
             default:
                 Console.WriteLine(String.Format("ObjectEventHandler: event {0}, ref {1}", inEvent.ToString("X"), inRef.ToString()));
                 break;
        }
        return 0x0;
    }
