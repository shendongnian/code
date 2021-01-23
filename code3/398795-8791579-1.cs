    class UsernameField : BaseField<string> { }
    [TestMethod]
    public void test()
    {
        var parent = new DynamicObject();
        var field = new UsernameField() { Value = "the username" };
        parent.Add(field);
        Assert.AreEqual("the username", parent.GetField<UsernameField>().Value);
    }
