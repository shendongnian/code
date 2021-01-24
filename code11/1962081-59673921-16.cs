    public IQueryable<DataModel.PersonNote> GetPersonNotes(int personId)
    {
        var personNotes = _context.PersonNotes
             .Include(x => x.Person)
             .Include(x => x.Author)
             .Where(p => p.PersonId == personId);
        return personNotes;
    }
