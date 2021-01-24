    [Test]
    public void AllVehiclesFromCallBackEndUpInProperty() {
        //Arrange
        MyAsyncCompletedEventHandler handler = null;
        var vehiclesMock = new Mock<IVehicles>();
        vehiclesMock
            .Setup(_ => _.ListVehicles(It.IsAny<string>(), It.IsAny<MyAsyncCompletedEventHandler>()))
            .Callback<string, MyAsyncCompletedEventHandler>((secret, callback) => {
                //capture the delegate for later use;
                handler = callback;
            });
        var subjectUnderTest = new VehiclesViewModel(vehiclesMock.Object);
        //check to make sure the hanler as been set at this point
        Assert.IsNotNull(handler);
        var vehicles = new List<Vehicle> {
            new Vehicle {Name = "TR3B"},
            new Vehicle {Name = "Aurora"},
            new Vehicle {Name = "HAUC"}
        }.ToArray();
        int expected = vehicles.Length;
        var eventArgs = new MyAsyncCompletedEventArgs(null) {
            Result = vehicles
        };
        //Act (invoke the delegate)
        handler.Invoke(vehiclesMock.Object, eventArgs);
        //Assert
        int actual = subjectUnderTest.VehicleRows.Count;
        Assert.AreEqual(expected, actual);
    }
