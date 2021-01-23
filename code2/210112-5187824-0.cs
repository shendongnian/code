    [Test]
    public void Test()
    {
         var invalidObject = new TestValidation { DateField = "bah" };
         var validationContext = new ValidationContext(invalidObject,null , null){MemberName = "DateField"};
         var validationResults = new System.Collections.Generic.List<ValidationResult>();
        
         var result = Validator.TryValidateProperty(invalidObject.DateField, validationContext, validationResults);
        
        Assert.IsFalse(result);
        Assert.AreEqual(1, validationResults.Count);
    }
