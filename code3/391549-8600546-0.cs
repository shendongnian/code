    abc instance = new abc();
    //then set the properties
    abc.Property1 = "Some value";
    //similarly set the value of rest of the properties.
    
    //insert this instance in your list by using add method
    list.Add(instance);
    
    //iterate through each instance in list
    
    foreach(abc instance in list)
    {
        //print value of a property
        console.Writeline(abc.Property1);
        //similarly other properties
    }
