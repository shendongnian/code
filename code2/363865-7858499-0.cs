    public static class PersonExtensions
    {
        public IEnumerable<Person> AllPeople(this IEnumerable<Person> people)
        {
            return people.Distinct();
        }
    }
