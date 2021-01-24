    private static List<Human> Convert(List<Person> persons)
    {
        List<Human> humans = new List<Human>();
        foreach (Person p in persons)
        {
            Human newHuman = new Human(p.Name, 12);
            if (p.Childs != null)
            {
                newHuman.SubHuman = convert(p.Childs);
            }
            humans.Add(newHuman);
        }
        return humans;
    }
