    public User.PersonNote MapGroupToPersonNotes(IGrouping<string, DataModels.PersonNote> personGroup)
    {
        User.PersonNote personNote = new PersonNote
        {
            Id = personGroup.First().Id,
            AuthorName = personGroup.First().AuthorName,
            AuthorId = personGroup.First().AuthorId,
            ///Assign the rest of the properties
            Attachments = personGroup.ToList().Select(x => new User.PersonNoteAttachment
                Alias = x.PersonNoteAttachment.Alias,  //This is DataModels.PersonNoteAttachment
                FileName = x.PersonNoteAttachment.FileName,
                MimeType = x.PersonNoteAttachment.MimeType
            )
        };
        return personNote;
    }
