    public void SavePerson(int age, string name, out Person person)
    {
        person = new Person();
        person.Age = age;
        person.Name = name;
    }
