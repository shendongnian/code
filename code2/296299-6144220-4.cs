    classA test = new classA() { Name = "Jeff Atwood", website = "codinghorror.com/blog", location = "El Cerrito, CA", age = 40, reputation = 15653 };
    
    
    var result = test.GetType().GetProperties().ToDictionary(property => property.Name,
                                                        property => property.GetValue(test,null),
                                                         StringComparer.OrdinalIgnoreCase);
    
    foreach (var key in result.Keys)
        Console.WriteLine("{0} : {1}", key, result[key]);
        
