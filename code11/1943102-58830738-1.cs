    using (var context = new Context())
    {
        var guests = context.Guests.ToList();
        var communicationTypes = context.CommunicationTypes.ToList();
        var communicationPreferences = context.CommunicationPreferences.ToList();
        var guest = guests.FirstOrDefault(x => x.Id == 1);
        guest.CommunicationPreference = new CommunicationPreference(1, guest.Id, communicationTypes.First().Id);
        context.SaveChanges();
    }
