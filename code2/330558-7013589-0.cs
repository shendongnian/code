    // cache it to avoid multiple time casting
    string bookingId = booking.EventID.ToString();
    
    // you can do filtering in the source array without converting it itno the numbers
    // as long as you won't have an Exception in case when one of the Ids is not a number
    if(EventIds.Split(',').Any(s => bookingId.Contains(s)))
    {
      // ..
    }
    else
    {
     // ...
    }
