    if (
            EventIds.Split(',').OfType<string>()
                .Any(e => booking.EventID.ToString().Contains(e))
        )
    {
        //Some member of a comma delimited list is part of a booking eventID ???
    }
    else
    {
        //Or Not
    }
