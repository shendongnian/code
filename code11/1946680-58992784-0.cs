    [Test]
    public void Delete_ReturnsOkResult_IfDeleteSuccess()
    {
      const int deleteId = 1234;
      mockService.Setup(x => x.DeleteSport(deleteId)).Returns(true);
      
      var result = controller.Delete(deleteId);
    
      var okResult = result as ObjectResult;    
      Assert.AreEqual(HttpStatusCode.OK, okResult.StatusCode);
    }
