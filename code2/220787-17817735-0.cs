    public class Test
        {
            //simulate an IQueryable
            private readonly IQueryable<Person> _people = new List<Person>().AsQueryable();
    
            public void FindContactMatchCount(Guid personId)
            {
                //we'll need the list of id's of the users contacts for comparison, we don't need to resolve this yet though so 
                //we'll leave it as an IQueryable and not turn it into a collection
                IQueryable<Guid> idsOfContacts = _people.Where(x => x.Id == personId).SelectMany(x => x.Contacts.Select(v => v.Id));
    
                //find all the people who have a contact id that matches the selected users list of contact id's
                //then project the results, this anonymous projection has two properties, the person and the  contact count
                var usersWithMatches = _people
                    .Where(x => idsOfContacts.Contains(x.Id))
                    .Select(z => new
                        {
                            Person = z, //this is the person record from the database, we'll need to extract display information
                            SharedContactCount = z.Contacts.Count(v => idsOfContacts.Contains(v.Id)) //
                        }).OrderBy(z => z.SharedContactCount)
                    .ToList();
            }
        }
