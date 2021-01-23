    [Test]
    public void ShouldOnlyValidateAlphaNamesLessThan50Chars() {
    
        var validator = new Validator();
        Assert.IsTrue(validator.validates("An Alpha Name"));
        Assert.IsFalse(validator.validates(
            "A Really Really Long Name that's 51 characters xx"));
        Assert.IsFalse(validator.validates("A name with 1234 numbers"));
    }
