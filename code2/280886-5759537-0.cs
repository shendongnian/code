    List<Person> persons = new List<Person>();
    
    persons.Add(new Person { FirstName = "saurabh", LastName = "sharma" });
    
    persons.Add(new Person { FirstName = "sandeep", LastName = "singh" });
    
    persons.Add(new Person { FirstName = "Ivan", LastName = "gupta" });                       
    
    Response.Write(string.Join(",", (from p in persons select p.FirstName).ToArray()));
