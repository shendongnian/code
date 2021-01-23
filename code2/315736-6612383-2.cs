    [Test]
    public void CanConvertListToBaseClass()
    {
        var list = new List<SuperClass>();
        list.Add(new SuperClass());
        var castedList = list.Cast<BaseClass>().ToList();
        Assert.That(castedList, Is.InstanceOf<IList<BaseClass>>());
    }
