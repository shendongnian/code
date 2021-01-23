    public MyPersonClassGetFirstNameAndLastName(int id)
    {
        var person = from p in People
                     where p.Id = id
                     select p;
        MyPersonClassreturnValue = new MyPersonClass;
        returnValue.FirstName = p.FirstName; 
        returnValue.LastName= p.LastName;
        return returnValue;
    }
