    if(action != null)
    {
        foreach(Action child in action.GetInvocationList())
        {
            try
            {
                child();
            }
            catch (Exception ex)
            {
                 // handle/log etc
            }
        }
    }
