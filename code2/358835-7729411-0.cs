    static class PersonListExtensions
    {
        public static List<string> ToStringList( this List<Person> persons)
        {
            return persons.Select(p=>p.Name).ToList();
        }
    }
