    [TestMethod]
    public void OneIsOne()
    {
        using (ConsoleRedirector cr = new ConsoleRedirector())
        {
            Assert.IsFalse(cr.ToString().Contains("New text"));
            /* call some method that writes "New text" to stdout */
            Assert.IsTrue(cr.ToString().Contains("New text"));
        }
    }
