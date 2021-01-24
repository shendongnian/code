csharp
[Test]
public void Work_Conflict()
{
    this.Service.Setup(x => x.DoWork()).Throws<SomeException>();
    IHttpActionResult result = this.MyController.Work();
    var objectResult = result as ObjectResult;
    Assert.IsNotNull(objectResult);
    dynamic model = objectResult.Value;
    string actual = (string)model.Message;
    string expected = "The message";
    Assert.AreEqual(expected, actual);
}
