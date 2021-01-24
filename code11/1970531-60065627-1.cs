    class Address
    {
        public string city { get; set; }
        public string country { get; set; }
    }
    class ObjectA
    {
        public int Id { get; set; }
        public Address address { get; set; }
    }
    class ObjectB
    {
        public int Id { get; set; }
        public ObjectA objectA { get; set; }
    }
    Expression<Func<ObjectB, bool>> expected = b =>
        (b.Id == 100) &&
        (b.objectA.Id > 1 && b.objectA.address.city == "City1" || b.objectA.address.country == "US");
    // Compile the Expression
    var expectedItems = expected.Compile();
    List<ObjectB> objBs = new List<ObjectB>();
    var address = new Address();
    var objA = new ObjectA();
    var objB = new ObjectB();
    address.city = "City1";
    address.country = "US";
    objA.Id = 1;
    objB.Id = 100;
    objA.address = address;
    objB.objectA = objA;
    objBs.Add(objB);
    address = new Address();
    objA = new ObjectA();
    objB = new ObjectB();
    address.city = "City2";
    address.country = "US";
    objA.Id = 3;
    objB.Id = 100;
    objA.address = address;
    objB.objectA = objA;
    objBs.Add(objB);
    // Use expectedItems
    var result = objBs.FirstOrDefault(b => expectedItems(b));
