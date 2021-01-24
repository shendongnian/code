    public static void DisplayPerson(List<Person> persons)
    {
        Stack<Person> personStack = new Stack<Person>();
        if (persons != null)
        {
            int level = 1;
            persons.ForEach(personStack.Push);
            while (personStack.Count > 0)
            {
                Person item = personStack.Pop();
                Console.WriteLine("-" + item.Name + ", Level:" + level); 
                if (item.Childs != null)
                {
                    item.Childs.ForEach(personStack.Push);
                    level++;
                }
            }
        }
    }
