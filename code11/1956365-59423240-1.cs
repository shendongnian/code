    public void AssignTo(ILine l)
    {
        var l1 = Assignment;
        // remove this line
        // this.AssignTo(l1.train)
        ((List<Train>)l1.Trains).Remove(this);
        ((List<Train>)l.Trains).Add(this);
        Assignment = l;
       
    }
