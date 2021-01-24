        Forename = fn;
        Surname = sn;
    }
    // getters
    public string DefaultName
    {
        get { return Forname + “ “ + Surname; }
    }
    public string ReversedName
    {
        get { return Surname + “ “ + Forename; }
    }
