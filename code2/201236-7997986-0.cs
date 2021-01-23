    public string IamGoingToThrowAnException 
    {
        get
        {
            throw new System.Exception("Caught me in design mode.");
        }
    }
