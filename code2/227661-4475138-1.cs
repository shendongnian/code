    [Test]
    public void DivisorsTest()
    {   
        int n = 0; 
        int expected = 0; //error
        IEnumerable<Integer> actual;
        actual = Science.Mathematics.NumberTheoryFunctions.Divisors(n);
        Assert.IsTrue(actual.All(x => x != expected));
    }
