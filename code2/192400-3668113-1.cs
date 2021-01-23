    private static Person GetPerson(string line)
    {
        string [] parts = line.Split('|'); // as per Dan Tao's suggestion
        return new Person {
            FirstName = parts[0],
            LastName = parts[1],
            Company = parts[2],
            FavoriteColor = parts[3],
            NameOfPetUnicorn = parts[4]
        };
    }
