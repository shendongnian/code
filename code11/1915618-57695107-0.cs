    public class Car : ICar
    {
        public virtual string Manufacturer { get; set; }
        public virtual string Model { get; set;}
        public virtual string Name => $"{Manufacturer} {Model}";
    }
    public class CarTestHelper : ICar
    {
        private readonly ICar _innerCar;
        public CarTestHelper(ICar car)
        {
            _innerCar = car;
        }
        // These properties use the existing instance passed in the constructor
        public string Manufacturer { get => _innerCar.Manufacturer; set => _innerCar.Manufacturer = value; }
        public virtual string Model { get => _innerCar.Model; set => _innerCar.Model = value; } // Virtual property can be mocked using Moq
        public string Name => _innerCar.Name; // Does NOT use mocked 'Model'.
    }    
    [TestFixture]
    public class CarTests
    {
        [Test]
        public void NameIsManufacturerWithModel()
        {
            var actualCar = new Car
            {
                Manufacturer = "Nissan",
                Model = "100NX"
            };
            var carMock = new Mock<CarTestHelper>(actualCar)  // Pass the decorated car as constructor parameter
            {
                CallBase = true
            };
            carMock.SetupGet(c => c.Model).Returns("200SX");
            Assert.AreEqual("Nissan 200SX", carMock.Object.Name);  // Will fail as the car will not used the mocked value.
        }
    }
