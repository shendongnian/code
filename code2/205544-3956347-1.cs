    using System.Linq
    [Test]
    public void GetCars_ReturnsMustangs()
    {
       Cars[] cars = GetCars();
       Assert.IsTrue(cars.Any(c => c.Type == "Mustang"));
    }
    
