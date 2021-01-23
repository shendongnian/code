    public Member( Dictionary<string,object> dictionary )
    { 
        fName = dictionary["fName"];
        lName = dictionary["lName"];
        email = dictionary["email"];
    }
    // usage Member m = new Member( inputDictionary );
