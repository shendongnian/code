    var personNotes = _context.PersonNotes
        .Join(_context.PersonNotesHistory, pn => pn.PersonId, pnh => pnh.PersonId, (pn, pnh) => new
        {
            pn.Note,
            pn.AuthorID,
            pn.CreatedBy,
            pnh.Note,
            pnh.AuthorID,
            pnh.CreatedBy
        })
        .ToList();
