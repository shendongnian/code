    public static void DisplayPerson(List<Person> persons, int level = 0)
    {
        if (persons != null)
        {
            level++;
            foreach (Person item in persons)
            {
                Console.WriteLine("-" + item.Name + ", Level" + level); 
                DisplayPerson(item.Childs, level);
            }
        }
    }
