[TestMethod]
void Test()
{
    var wizard = MockObject<TestSpell>();
}
private Mock<IWizard> MockObject<T>() where T : SpellBase, IComponents
{
    var mock = new Mock<IWizard>();
    mock.Setup(pa => pa.Cast(It.IsAny<T>()))
        .Returns(true);
    return mock;
}
private class TestSpell : SpellBase, IComponents
{ }
`TestSpell ` class is only required in your test project
