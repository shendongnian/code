    using System.Collections.Generic;
    using System.Linq;
    public static Persons FindPerson(IEnumerable<Person> persons, int id)
    {
        return persons.FirstOrDefault(p => p.ID == id);
    }
