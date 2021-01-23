    class PersonIdEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.ID == y.ID;
        }
        public int GetHashCode(Person person)
        {
            return person.ID;
        }
    }
    var result = list1.Concat(list2)
        .OrderByDescending(i => DateTime.Parse(i.ChangeDate)) // Most recent first
        .Distinct(new PersonIdEqualityComparer())
        ;
