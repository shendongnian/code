     List<Note> notes = apiNotes.Select(x => new Note()
        {
            noteId = x.NoteId,
            date = x.DateEntered.Date.ToString("MMMM dd"),
            time = x.DateEntered.ToString("h:mm tt"),
            body = x.Text,
            title = x.Title,
            author = (!string.IsNullOrEmpty(x.CreatedBy))
                   ? new Note.Author() { fullname = x.CreatedBy, 
                                         initial = initials.Replace(x.CreatedBy, "$1") }
                   : null
        }).ToList();
