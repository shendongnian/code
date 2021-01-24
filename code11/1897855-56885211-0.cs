    internal void Update(Contracts c)
    {
        this.Num = c.Num;
        this.Salary = c.Salary;
        this.Worker = c.Worker;
        this.FullName = c.FullName;
        this.DateConclusion = c.DateConclusion;
        this.DateStartWork = c.DateStartWork;
        this.DateEndWork = c.DateEndWork;
        this.ListKindWorks = c.ListKindWorks;
        this.ListSubjects = c.ListSubjects;
    }
    private void Update(Contracts oldValue, Contracts newValue)
    {
        using (ModelContext context = new ModelContext())
        {
            context.Attach(oldValue);
            oldValue.Update(newValue);
            // oldValue = newValue; // .Attach does not respond to this
            context.SaveChanges();
        }
    }
