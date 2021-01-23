    [Test]
    public void TypeEquality()
    {
        var monkey = new Monkey();
        var areEqual = (monkey.GetType() == typeof(Monkey));
        Assert.That(areEqual, Is.True);
    }
