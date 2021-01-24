    public IQueryable<IGrouping<string, PersonNote>> GetPersonNotes(int personId)
    {
        var personNotes = _context.PersonNotes
             .Include(x => x.Person)
             .Include(x => x.Author)
             .Include(x => x.PersonNoteAttachment)
             .Where(p => p.PersonId == personId)
             .GroupBy(x => x.Author.FirstName);
        return personNotes;
    }
