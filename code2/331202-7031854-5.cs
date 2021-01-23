    // using Moq for mocking
    [Test]
    public void HiringOfficerCommunicatesAdditionOfNewEmployee() {
        var mockEmployeeManager = new Mock<EmployeeManager>(); // Arrange
        var officer = new HiringOfficer(mockEmployeeManager.Object);
        var prospect = CreateProspect();
    
        officer.HireProspect(prospect); // Act
    
        mockEmployeeManager.Verify(m => m.AddEmployee(prospect), Times.Once); // Assert
    }
