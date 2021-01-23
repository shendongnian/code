    string[] search = new string[] { "Bush", "111", "John" };
    var customers = new[]   { 
                                new {FName = "Dick", Surname = "Bush", Phone = "9512221111", DOB = new DateTime(1980,01,01), Address = "John Street 1" },
                                new {FName = "John", Surname = "Smith", Phone = "3051112222",  DOB =  new DateTime(1978,01,01), Address = "Roosevelt Av 787"}
                            };
    
    
    var result = customers.Where(customer => search.All(term =>
                        customer.FName.Contains(term)
                        || customer.Surname.Contains(term)
                        || customer.DOB.ToString().Contains(term)
                        || customer.Phone.Contains(term)
                        || customer.Address.Contains(term)
                        ));
