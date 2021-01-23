    [Test]
    public void Test()
    {
        var invalidObject = new TestValidation {DateField = "bah"};
        var validationContext = new ValidationContext(invalidObject, null, null);
        var validationResults = new System.Collections.Generic.List<ValidationResult>();
        //Validate all attributes
        bool result = Validator.TryValidateObject(invalidObject, validationContext, validationResults, true);
        Assert.IsFalse(result);
        Assert.AreEqual(1, validationResults.Count);
    }
