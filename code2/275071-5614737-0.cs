    public Factory(string name, Person manager)
    {   if (Manager.WorkPlace != null && Manager.WorkPlace.Manager==manager)
        { 
            var errmsg = "Cannot pass an existing manager to Factory constructor.";
            throw new ArgumentException("manager",errmsg);
        }
        Name = name;
        Manager = manager;
        Manager.WorkPlace = this;
    }
