     var existingGuests = @event.Guests.ToList();
     // GetNewGuestsIds will return the new guests list (3,4,5)
     foreach (var guestId in GetNewGuestsIds())
     {
        if (existingGuests.RemoveAll(g => g.Id == guestId) == 0)
        {
           guest = db.Guests.CreateObject();
           // fill guest data here
           @event.Guests.AddObject(guest);
        }
     }
     existingGuests.ForEach(g => @event.Guests.Remove(g));
