    If (EventIDs.Split(',').Select(s => 
        int.Parse(s)).OfType<int>().Contains(booking.EventID))
    {
        //Ther booking ID is in the list
    }
    else
    {
        //It isn't
    }
         
