    class Person
    {
        public int Id { get; private set; }
        public string NameHash { get; private set; }
        public string Name { get; private set; }
        public Person(int id, string nameHash, string name)
        {
            Id = id;
            NameHash = nameHash;
            Name = name;
        }
    }
    class People : IEnumerable<Person>
    {
        private Dictionary<int, Person> personDictionary = new Dictionary<int, Person>();
        private Dictionary<string, int> hashIdMap = new Dictionary<string, int>();
        public void Add(Person person)
        {
            if (person == null)
                throw new ArgumentNullException("person");
            if (personDictionary.ContainsKey(person.Id))
                throw new InvalidOperationException("person Id is already referenced in collection.");
            if (hashIdMap.ContainsKey(person.NameHash))
                throw new InvalidOperationException("person NameHash is already referenced in collection.");
            personDictionary.Add(person.Id, person);
            hashIdMap.Add(person.NameHash, person.Id);
        }
        public Person this[int id]
        {
            get
            {
                if (!personDictionary.ContainsKey(id))
                    throw new ArgumentOutOfRangeException("Id is not in the collection.");
                return personDictionary[id];
            }
        }
        public Person this[string nameHash]
        {
            get
            {
                if (!hashIdMap.ContainsKey(nameHash))
                    throw new ArgumentOutOfRangeException("NameHash is not in the collection.");
                return this[hashIdMap[nameHash]];
            }
        }
        public IEnumerator<Person> GetEnumerator()
        {
            foreach (KeyValuePair<int, Person> pair in personDictionary)
                yield return pair.Value;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
...
    static void Main()
    {
        Person personA = new Person(1, "A", "Apple");
        Person personB = new Person(2, "B", "Banana");
        Person personC = new Person(3, "C", "Cherry");
        People people = new People();
        people.Add(personA);
        people.Add(personB);
        people.Add(personC);
        Person foo = people[1];
        Person bar = people["C"];
        Debug.Assert(foo.Name == "Apple");
        Debug.Assert(bar.Name == "Cherry");
        foreach (Person person in people)
            Debug.WriteLine(person.Name);
    }
