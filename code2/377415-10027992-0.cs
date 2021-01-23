    public enum Answer { Object, String, Int32, FileInfo };
    private Answer GetAnswer(int i) { return Answer.Int32; }
    private Answer GetAnswer(string s) { return Answer.String; }
    private Answer GetAnswer(object o) { return Answer.Object; }
    [TestMethod]
    public void MusingAboutNullAtRuntimeVsCompileTime()
    {
        string nullString = null;
        object nullStringAsObject = (string)null;
        object stringAsObject = "a string";
        // resolved at runtime
        Expect.Throws(typeof(ArgumentNullException), () => Type.GetTypeHandle(nullString));
        Expect.Throws(typeof(ArgumentNullException), () => Type.GetTypeHandle(nullStringAsObject));
        Assert.AreEqual(typeof(string), Type.GetTypeFromHandle(Type.GetTypeHandle(stringAsObject)));
        Assert.AreEqual(typeof(string), stringAsObject.GetType());
        // resolved at compile time
        Assert.AreEqual(Answer.String, this.GetAnswer(nullString));
        Assert.AreEqual(Answer.Object, this.GetAnswer(nullStringAsObject));
        Assert.AreEqual(Answer.Object, this.GetAnswer(stringAsObject));
        Assert.AreEqual(Answer.Object, this.GetAnswer((object)null));
        Assert.AreEqual(Answer.String, this.GetAnswer((string)null));
        Assert.AreEqual(Answer.String, this.GetAnswer(null));
    }
    // Uncommenting the following method overload
    // makes the last statement in the test case ambiguous to the compiler
    // private Answer GetAnswer(FileInfo f) { return Answer.FileInfo; }
