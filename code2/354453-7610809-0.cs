    public bool Process(int choice)
    {
        try
        {
            Thing thing = GetRequiredThing(choice);
            SubThing subThing = (SubThing)thing;
        }
       catch (InvalidCastException ex)
       {
           // report ex.
           return false;
       }
    }
