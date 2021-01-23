    Places = new List<AbstractGeneralParticipants>(places.Count);
    foreach (Place place in places)
    {
        Places.Add(new GeneralParticipants(place));
    }
