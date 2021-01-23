    [TestMethod]
    public void CreateInvalidContact()
    {
        // Arrange
        var contact = new Contact();
        _service.Expect(s => s.CreateContact(contact)).Returns(false);
        var controller = new ContactController(_service.Object);
        // Act
        var result = (ViewResult)controller.Create(contact);
        // Assert
        Assert.AreEqual("Create", result.ViewName);
    }
