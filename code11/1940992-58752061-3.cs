csharp
[Test]
public void Work_Conflict()
{
    this.Service.Setup(x => x.DoWork()).Throws<SomeException>();
    IHttpActionResult result = this.MyController.Work();
    Assert.AreEqual("The message", (YourClass) result.Message);
    // YourClass should be the return type of this.Content(...)
}
