    var database = _mongoServer.GetDatabase("StackoverflowExamples");
    
    var p = new Person() { Name = "Testperson" };
    var persons = database.GetCollection<Person>("Persons");
    persons.Save<Person>(p);
    
    var group = new Group() { Description = "A fancy descriptor" };
    group.Add(p);
    var groups = database.GetCollection<Group>("Groups");
    groups.Save<Group>(group);
    
    //Groups collection
    //{
    //  "_id": "4da54d3c00a9ec06a0067456",
    //  "Description": "A fancy descriptor",
    //  "persons": [
    //    {
    //      "_id": "4da54d3b00a9ec06a0067455",
    //      "Name": "Testperson"
    //    }
    //  ]
    //}
    
    //Persons collection
    //{
    //  "_id": "4da54d3b00a9ec06a0067455",
    //  "Name": "Testperson"
    //}
    
    
    var readPerson = persons.FindOneById(p.Id);
    readPerson.Name = "a different name";
    //Here i've changed Insert to Save
    persons.Save(readPerson);
    
    //Here you updating person in persons collection, 
    //but within group name still old
    
    //Persons collection
    //{
    //  "_id": "4da54d3b00a9ec06a0067455",
    //  "Name": "a different name"
    //}
    
    //So to achieve 'physical relation' you need also update person within group
    var query = Query.EQ("persons._id", readPerson.Id);
    groups.Update(query, Update.Set("persons.$.Name", readPerson.Name));
    
    //Groups collection
    //{
    //  "_id": "4da54d3c00a9ec06a0067456",
    //  "Description": "A fancy descriptor",
    //  "persons": [
    //    {
    //      "_id": "4da54d3b00a9ec06a0067455",
    //      "Name": "a different name"
    //    }
    //  ]
    //}
    
    
    //Test passed
    var readGroup = groups.FindOneById(group.Id);
    Assert.AreEqual(readPerson.Id, readGroup.persons[0].Id); 
    Assert.AreEqual(readPerson.Name, readGroup.persons[0].Name); 
