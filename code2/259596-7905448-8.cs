    public void Test()
    {
        var dogType = typeof (Dog);
        var catType = typeof (Cat);
        Assert.AreEqual(Dog.Type.Sound, AnimalType.Get(dogType).Sound);
        Assert.AreEqual(Cat.Type.Sound, AnimalType.Get(catType).Sound);
    }
