    public static void DisplayPerson(List<Person> persons, int level = 0)
    {
        if (persons != null)
        {
            foreach (Person item in persons)
            {
                level++;
                Console.WriteLine("-" + item.Name + ", Level" + level); 
                DisplayPerson(item.Childs, level);
            }
        }
    }
