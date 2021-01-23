    var client = new Service1Client();
    
    var genericType = new GenericType
                            {
                                Data = new[]
                                            {
                                                new MyType(),
                                            }
                            };
    var result = client.GetDataUsingDataContract(genericType);
    client.Close();
    
    Console.WriteLine(result.Data.First().Stuff);
    
    Console.ReadLine();
