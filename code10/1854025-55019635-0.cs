    public static void DisplayPerson(List<Person> persons, int level = 0)
    {
        if (persons != null)
        {
            foreach (Person item in persons)
            {
                Console.WriteLine("-" + item.Name + ", Level" + (level + 1)); 
                DisplayPerson(item.Childs, level + 1);
            }
        }
    }
