 [Test]
 [Author("Author_Name")]
 public void TestTest() { /* ... */ }
}
and retrieve using below in TearDown method
var category = (string) TestContext.CurrentContext.Test.Properties.Get("Author");
