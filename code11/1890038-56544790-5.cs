    public static Person operator+ (Person a, Person b) 
    {
       return new Person() { Name = a.Name + " " + b.Name };
    }
    public void TestForPersonAddition()
    {
        var expectedValue = "Billie Jean";
        
        var billie = new Person() { Name = "Billie" };
        var jean = new Person() { Name = "Jean" };
        Assert.AreEqual(billie + jean,expectedValue);
    }
