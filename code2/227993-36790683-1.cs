     [TestMethod]
     public void All_ShouldReturnPartialViewCalledStatusFilter()
     {
         // Arrange
         var controller = new StatusController();
         // Act
         var result = controller.StatusFilter() as PartialViewResult;
         // Assert
         Assert.AreEqual("_StatusFilter", result.ViewName, "All action on Status Filter  controller did not return a partial view called _StatusFilter.");
      }
