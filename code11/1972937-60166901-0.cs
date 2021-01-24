    private static List<Person> InitializeClassroom()
    {
        var people = new List<Person>();
        for (int i = 1; i <= 10; i++)
        {
            var person = new Person()
            {
                number = i,
                pass = false
            };
            people.Add(person);
        }
        return people;
    }
