    public static T FindPerson<T>(IEnumerable<T> persons, int noteid)
        where T : Person
    {
        foreach (T person in persons)
        {
            if (person.ID == noteid)
            {
                return person;
            }
        }
        return null;
    }
    public static User SelectUser(User[] users)
    {
        while (true)
        {
            Console.Write("Please enter the User id: ");
            string input = Console.ReadLine();
            int id;
            if (int.TryParse(input, out id))
            {
                User person = Persons.FindPerson(users, id);
                if (person != null)
                {
                    return person;
                }            
            }
            Console.WriteLine("The User does not exist. Please try again.");                
        }
    }
    
