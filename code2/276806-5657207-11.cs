    public void Add(Contact contact)
    {
    	if (!validator.IsValid(contact)) throw new ArgumentException();
    
    	unitOfWork.Execute(() => repository.Save(contact));
    }
