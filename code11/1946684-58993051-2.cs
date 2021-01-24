c#
[Test]
public void Delete_ReturnsOkResult_IfDeleteSuccess()
{
  bool isSucceed = true;
  const int deleteId = 1234;
  
  this.MockSportService(isSucceed);
  var result = controller.Delete(deleteId);
  var okResult = result as ObjectResult;    
  Assert.AreEqual(HttpStatusCode.OK, okResult.StatusCode);
}
2) Failure:
c#
[Test]
public void Delete_ReturnsNotFound_IfIdNotFound()
{
  bool isSucceed = false;
  const int deleteId = 1234;
  
  this.MockSportService(isSucceed);
  var result = controller.Delete(deleteId);
// Do proper asserts
}
3) Exceptions,
c#
[Test]
public void Delete_ThrowsException_IfIdNotFound()
{
  bool isSucceed = false;
  const int deleteId = 1234;
  
   mockService.Setup(x => x.DeleteSport(It.IsAny<int>())).
        Throws(new Exception());
  // Act
  var result = controller.Delete(deleteId);
  // Assert
  Assert.IsInstanceOf<StatusCodeResult>(result);
  Assert.AreEqual(400, result.StatusCode);
}
And have the common method for mocking for success and failure,
c#
private void MockSportService(bool isSucceed)
{
mockService.Setup(x => x.DeleteSport(deleteId)).Returns(isSucceed);
}
