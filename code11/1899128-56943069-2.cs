    var participantVMs = db.Participants.Where(x => /* some condition */)
        .Select(x => new ParticipantViewModel
        {
            ID = x.ID,
            FullName = x.firstname + " " + x.lastname,
            Alias = x.alias,
            IsConfirmed = x.Confirmations.Any(c => c.is_confirmed)
         }).ToList();
