    public String RetrieveSesssion()
    {
        string sessionvar = SaveSession();
        if (sessionvar != null)
        {
            return sessionvar;
        }
        else
        {
            return "Session is empty";
        }
    }
    
