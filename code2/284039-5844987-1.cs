    var a = new TheFox("x", "y");
    var json = JsonConvert.SerializeObject(a);
    Console.WriteLine(json);
    
    var returned = JsonConvert.DeserializeAnonymousType(json, new TheFox("q", "a")); 
                
    Assert.That(a.Id, Is.EqualTo(returned.Id));
    Assert.That(a.Name, Is.EqualTo(returned.Name));
