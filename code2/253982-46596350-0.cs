    [Test]
    public void TestFavouritePeople()
    {
        var people = GetFavouritePeople();
        var names = people.Select(p => p.Name);
        var expectedNames = new[] {"joe", "fred", "jenny"};
        var actualNames = names.Intersect(expectedNames);
        CollectionAssert.AreEquivalent(expectedNames, actualNames);
    }
