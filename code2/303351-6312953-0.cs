    public Bll() : this (new Dal()) { }
    
    public Bll(IDal dal) // to provide other IDal implementations if needed
    {
        this.dal = dal;
    }
