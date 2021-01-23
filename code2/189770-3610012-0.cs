    public string FullName
    {
        get { return Name + Surname; }
        set 
        {
            // You should do some validation while and before splitting the value
            this.Name = value.Split(new []{' '})[0];
            this.Surname = value.Split(new []{' '})[1];
        }
    }
