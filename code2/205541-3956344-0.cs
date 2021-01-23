    [Test]
    public void GetCars_ReturnsMustangs()
    {
        Cars[] cars = GetCars();
        Assert.IsTrue(cars.Where(c => c.Type == "Mustang").Count() > 0);
    }
