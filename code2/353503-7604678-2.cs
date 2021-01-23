    public IEnumerable<VisitDetails> GetGuestVisiterList(int paperId)
    {
        using (var db = _dbFactory.GetDatabase())
        {
            return (from p in db.People
                    where p.Roles.Any(a => a.Name == "Guest")
                    select new GuestVisitDetails
                     {
                         PersonId = p.PersonId,
                         Forename = p.Forename,
                         Surname = p.Surname,
                         NumberOfVisits = p.Visits.Count(v => v.VisitStatus != "Complete")
                     }).ToList();
        }    
    }
