c#
[OneTimeSetUp]
public void GrabTheAuthor()
{
    _fixtureAuthor = TestContext.CurrentContext.Test.Properties.Get("Author").ToString();
}
