    public static class PersonImageBuilders
    {
        public static Image CreateMen(IPerson person)
        {
            if (person.Age > 60)
                return new Image("Old and gready!");
            else
                return new Image("Young and foolish!");
         
        }
    }
