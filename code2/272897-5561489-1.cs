    public Tuple<string, string> GetFirstNameAndLastName(int id)
    {
       var person = from p in People
                 where p.Id = id
                 select p;
       return new Tuple<string, string>(p.FirstName, p.LastName);
       // OR
       // return Tuple.Create(p.FirstName, p.LastName);
    }
