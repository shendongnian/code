    void SignalActors()
    {
        SomeAction newActors = null;
        foreach (SomeAction actor in Actors.GetInvocationList())
        {
            if (actor("Blah blah blah"))
            {
                newActors += actor;
            }
        }
        Actors = newActors;
    }
