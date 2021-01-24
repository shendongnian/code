    public IEnumerable<PersonNote> GetPersonNotes(int personId)
        {
            var personNotes = (from p in _context.Person
                               join pn in _context.PersonNotes on pn.PersonId equals p.Id
                               join pnh in _context.PersonNotesHistory on pn.PersonId equals pnh.PersonId
                               select new PersonNote
                               {
                                   AuthorId = pn.AuthorId,
                                   Created = pn.Created,
                                   Note = pn.Note,
                                   AuthorName = p.FirstName + " " + p.LastName,
                               }
                               );
            return personNotes;
        }
