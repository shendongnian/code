    Person oPerson1 = (from c in dt.AsEnumerable()
    select new Person
    {
        Name = c.Field<string>("Name"),
        HQ = c.Field<bool>("HQ")
    }).First(); //first person in a list
    
    
    Person oPerson2 = (from c in dt.AsEnumerable()
    select new Person
    {
        Name = c.Field<string>("Name"),
        HQ = c.Field<bool>("HQ")
    }).Skip(1).First(); //second person in a list
    
    However this code can be rewritten to be clearer:
    
    List<Person> persons = from c in dt.AsEnumerable()
    select new Person
    {
        Name = c.Field<string>("Name"),
        HQ = c.Field<bool>("HQ")
    };
       
    Person oPerson1 = persons[0];
    Person oPerson2 = persons[1];
