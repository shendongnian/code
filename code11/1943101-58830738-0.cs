        var guests = new Context().Guests.ToList(); // Context 1
        var communicationTypes = new Context().CommunicationTypes.ToList(); // Context 2
        var communicationPreferences = new Context().CommunicationPreferences.ToList(); // Context 3
        using (var context = new Context()) // Context 4
        {
            var guest = guests.FirstOrDefault(x => x.Id == 1);
            // This works
            context.CommunicationPreferences.Add(new CommunicationPreference(1, guest.Id, communicationTypes.First().Id));
            // This does not work - why? :(
            guest.CommunicationPreference = new CommunicationPreference(1, guest.Id, communicationTypes.First().Id);
            context.SaveChanges();
        }
