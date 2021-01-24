csharp
[Test]
public void Work_Conflict()
{
    this.Service.Setup(x => x.DoWork()).Throws<SomeException>();
    SomeException e = Assert.Throws<SomeException>(() => this.MyController.Work());
    Assert.AreEqual("The message", e.Message);
}
