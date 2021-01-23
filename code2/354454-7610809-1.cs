    public bool Process(int choice)
    {
        Thing thing = GetRequiredThing(choice);
        SubThing subThing = thing as SubThing;
        if (subThing == null)
        { 
            //report error;
            return false;
        }
    }
