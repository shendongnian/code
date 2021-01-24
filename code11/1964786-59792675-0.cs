    static void Main(string[] args)
        {
            List<Person> Persons = new List<Person>();
            foreach (Person person in Persons)
            {
                Console.WriteLine(person.Id);
                if (person.Siblings != null && person.Siblings.Count != 0)
                {
                    List<Person> people = GetPersons(person.Siblings);
                    foreach (Person person1 in people)
                        Console.WriteLine(person1.Id);
                }
            }
        }
    private static List<Person> GetPersons(List<Person> sibling)
    {
        List<Person> people = new List<Person>();
        foreach(Person person in sibling)
        {
            people.Add(person);
            if(person.Siblings != null && person.Siblings.Count!=0)
            {
                List<Person> people1 = GetPersons(person.Siblings);
                people.AddRange(people1);
            }
        }
        return people;
    }
