    public IEnumerable<User.PersonNote> GetPersonNotesAndAttachments(int personID)
    {
        var personNotes = _organisationRepository.GetPersonNotes(id).Select(x => 
            new User.PersonNote
            {
                //assign all properties
                Attachments = _organisationRepository.GetAttachments(x.PersonNoteID).Select(y => 
                new User.PersonNoteAttachment
                {
                    FileName = y.FileName,
                    Alias = y.Alias,
                    MimeType = y.MimeType
                }).AsEnumerable(),
            PersonId = x.PersonId,
            AuthorName = x.Person.FirstName + " " + x.Person.LastName,
            Note = x.Note,
            Id = x.Id,
            Created = x.Created
            });
        return personNotes;
    }
