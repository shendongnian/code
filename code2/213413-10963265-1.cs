    [Test]
    public void UpperCaseFirstCharacter_ZeroLength_ReturnsOriginal()
    {
        string orig = "";
        string result = orig.UpperCaseFirstCharacter();
        Assert.AreEqual(orig, result);
    }
    [Test]
    public void UpperCaseFirstCharacter_SingleCharacter_ReturnsCapital()
    {
        string orig = "c";
        string result = orig.UpperCaseFirstCharacter();
        Assert.AreEqual("C", result);
    }
    [Test]
    public void UpperCaseFirstCharacter_StandardInput_CapitalizesFirstLetterLeavesRestAsIs()
    {
        string orig = "this is Brian's test.";
        string result = orig.UpperCaseFirstCharacter();
        Assert.AreEqual("This is Brian's test.", result);
    }
