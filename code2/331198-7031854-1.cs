    // you have an interface IEmployeeManager and a stub class
    // called TestableEmployeeManager that implements IEmployeeManager
    // that is pre-populated with test data
    [Test]
    public void HiringOfficerAddsProspectiveEmployeeToDatabase() {
        var manager = new TestableEmployeeManager(); // Arrange
        var officer = new HiringOfficer(manager); // BTW: poor example of real-world DI
        var prospect = CreateProspect();
        Assert.AreEqual(4, manager.EmployeeCount());
    
        officer.HireProspect(prospect); // Act
    
        Assert.AreEqual(5, manager.EmployeeCount()); // Assert
        Assert.AreEqual("John", manager.Employees[4].FirstName);
        Assert.AreEqual("Doe", manager.Employees[4].LastName);
        //...
    }
