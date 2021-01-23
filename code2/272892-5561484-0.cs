    public string, string GetFirstNameAndLastName(int id, out string first, out string last)
    {
        var person = from p in People
                     where p.Id = id
                     select p;
        first = p.FirstName;
        last = p.LastName;
    }
