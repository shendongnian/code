    public String RetreiveSesssion()
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
    
    this works fine!!
