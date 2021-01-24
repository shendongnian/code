[Test]
public void MyTest()
{
    var systemUnderTest = new SystemUnderTest();
    var expected = "INSERT INTO blah blah";
    var actual = systemUnderTest.DoThingThatGetsASqlString();
    TestContext.WriteLine($"The full SQL string was: '{sqlString}'");
    
    Assert.AreEqual(expected, actual);
}
[1]: https://i.stack.imgur.com/dyIcn.png
