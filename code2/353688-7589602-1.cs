    [Test]
    public void TestDictionary2()
    {
        var alpha = new Dictionary();
        var bravo = new Dictionary();
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine("{0} - {1}", alpha.GetNext(), bravo.GetNext());
        }
    }
