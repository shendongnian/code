    public PersonDetailViewModel> GetPerson(int personId)
    {
        using (var ctx = new DBContext) 
        {
            var person = ctx.Persons
                .Select(x => new PersonDetailViewModel
                {
                   PersonId = x.PersonId,
                   Name = x.Name,
                   TypeName = x.Type.Name,
                   // ... Can load all visible properties and initial, important related data...
                }).Single(x => x.PersonId == personId);
            //...
            return person;
        }
    }
