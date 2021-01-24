    private string _name;
    public string Name
    {
        get
        {
            return _name; 
        }
        set
        {
            var nameChange = new NameChangeEventArgs(Name);
            OnNameChange(nameChange);
        
            _name = value; 
         } 
    }
