    [UnitOfWork]
    public void Add(Contact contact)
    {
    	if (!validator.IsValid(contact)) throw new ArgumentException();
    
    	repository.Save(contact);
    }
