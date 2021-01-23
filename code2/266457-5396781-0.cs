    // Create the collection
    Dictionary<string, Contact> myCollection = new Dictionary<string, Contact>();
    
    // Create your local object
    var localContact = new Contact { Name = "MyLocalContact" };
    
    // Add the local object to the collection
    myCollection.Add(localContact.Name, localContact);
    
    // Retrieve the local object by name
    var myContact = myCollection["MyLocalContact"];
