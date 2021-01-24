    public static void DisplayPerson(List<Person> persons)
    {
        Stack<Person> personStack = new Stack<Person>();
        persons.ForEach(personStack.Push);
        while(personStack.Count > 0)
        {
            Person item = personStack.Pop();
            Console.WriteLine("-" + item.Name); 
            item.Childs.ForEach(personStack.Push);
        }
    }
