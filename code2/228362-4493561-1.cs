    public static void SomeMethod (List<SomeClass> group) {
        IEnumerable<SomeClass> groupWithFalse =(from SomeClass gr in group
                                                where gr.SomeProp== false
                                                select gr);
        if(groupWithFalse.Any()) {
            foreach (SomeClass grFalse in groupWithFalse) {
                grFalse.Save();
            }
    
            // do some stuff
        }
    }
