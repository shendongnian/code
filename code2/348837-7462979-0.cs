    class Person
    {
        public string Name {get; set;}
    }
    
    void Test()
    {
        var joe1 = new Person {Name="Joe"};
        var joe2 = new Person {Name="Joe"};
    
        Assert.AreNotEqual(joe1, joe2);
    }
