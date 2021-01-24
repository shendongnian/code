var testController = new TestController();
With this you can then call the methods.
[Test]
public void TestHealth(){
  var testController = new TestController();
  var result = testController.GetHealth() as HttpResponseMessage
  Assert.That(result, Is.Not.Null);
  Assert.That(result.StatusCode, Is.EqualTo(200));
}
