    If (publishIEvent == true)
    {
       var eventMessage = Bus.CreateInstance<IEvent>()
    }
    else
    {
       var eventMessage = new EventMessage();
    }
