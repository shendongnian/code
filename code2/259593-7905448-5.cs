    public void StaticMethodInterface()
    {
        Animal dog = new Dog();
        Animal cat = new Cat();
        Assert.AreEqual(dog.AnimalType.Sound, Dog.Type.Sound);
        Assert.AreEqual(cat.AnimalType.Sound, Cat.Type.Sound);
    }
