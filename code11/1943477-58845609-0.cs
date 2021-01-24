        public void Write()
        {
            person.name = Input;
            if (!persons.Contains(person))
                persons.Add(person);
            People = persons;
        }
