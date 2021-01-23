    if (objectX.EventX != null)
    {
        foreach (Delegate existingHandler in objectX.EventX.GetInvocationList())
        {
                if (existingHandler == HandlerB)
                {
                    // registered
                }
        }
    }
