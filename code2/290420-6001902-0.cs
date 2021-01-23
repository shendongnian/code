    class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
    }
    
    class Address
    {
        public int AddressId { get; set; }
        public string Name { get; set; }
        public int PersonId { get; set; }
    }
    
    class Extra
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public void TestFlexibleMultiMapping()
    {
        var sql = 
    @"select 
    1 as PersonId, 'bob' as Name, 
    2 as AddressId, 'abc street' as Name, 1 as PersonId,
    3 as Id, 'fred' as Name
    ";
        var personWithAddress = connection.Query<Person, Address, Extra, Tuple<Person, Address,Extra>>
            (sql, (p,a,e) => Tuple.Create(p, a, e), splitOn: "AddressId,Id").First();
    
        personWithAddress.Item1.PersonId.IsEqualTo(1);
        personWithAddress.Item1.Name.IsEqualTo("bob");
        personWithAddress.Item2.AddressId.IsEqualTo(2);
        personWithAddress.Item2.Name.IsEqualTo("abc street");
        personWithAddress.Item2.PersonId.IsEqualTo(1);
        personWithAddress.Item3.Id.IsEqualTo(3);
        personWithAddress.Item3.Name.IsEqualTo("fred");
    
    }
