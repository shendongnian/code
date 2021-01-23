    public static class PersonCollectionExtensions
    {
        public static List<Person> ToList(this IEnumerable<Person> self)
        {
             return new PersonCollection(self);
        }
    }
