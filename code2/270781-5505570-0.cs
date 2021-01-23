    [TestMethod] public void SomeMethod_WithValidArgs1_Succeeds()
    {
        Assert_ThatSomeMethodSucceeds(0, "bla");
    }
    [TestMethod] public void SomeMethod_WithValidArgs2_Succeeds()
    {
        Assert_ThatSomeMethodSucceeds(1, "bla");
    }
    [TestMethod] public void SomeMethod_WithValidArgs3_Succeeds()
    {
        Assert_ThatSomeMethodSucceeds(1, "funcy");
    }
    private static void Assert_ThatSomeMethodSucceeds(
        int param1, string param2)
    {
        // Act
        SubSystem.SomeMethod(param1, param2);
    }
