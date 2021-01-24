csharp
[Test]
public void Work_Conflict()
{
    this.Service.Setup(x => x.DoWork()).Throws<SomeException>();
    IHttpActionResult result = this.MyController.Work();
    Assert.AreEqual("The message", result.Message);
}
**Update**
replace `result.Message` with `(YourClass) result.Message` where `YourClass` is the type returned by `this.Content(...)`.
