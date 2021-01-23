    List<IProxy> GetList() 
    { 
        List<IProxy> people = new List<IProxy>(); 
     
        people.Add(new Person()); 
        people.Add(new Person()); 
     
        return people; 
    } 
