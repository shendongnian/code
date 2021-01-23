    [Test]
    public void TestFavouritePeople()
    {
        var people = GetFavouritePeople();
        var names = people.Select(p => p.Name);
        var expectedNames = new[] {"joe", "fred", "jienny"};
        var actualNames = names;
        Assert.That(actualNames, Is.SupersetOf(expectedNames)); 
    }
