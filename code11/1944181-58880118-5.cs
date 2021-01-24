    [TestMethod]
    public void TestNotUrl()
    {
        var modelFail = new TestModel { Text = "Here you can find some crazy deals - http://crazydeals.com/notsocrazydeals and you can buy some high quality toys" };
        var modelPass = new TestModel { Text = "Here you can find some crazy deals - http:// crazydeals.com /notsocrazydeals and you can buy some high quality toys" };
        var result = new List<ValidationResult>();
        var context = new ValidationContext(modelFail) { MemberName = "Text" };
        var expectNotValid = System.ComponentModel.DataAnnotations.Validator.TryValidateProperty(modelFail.Text, context, result);
        var expectValid = System.ComponentModel.DataAnnotations.Validator.TryValidateProperty(modelFail.Text, context, result);
        Assert.IsFalse(expectNotValid, "Expected modelFail.Text not to validate, as it contains a URL.");
        Assert.IsFalse(expectValid, "Expected modelFail.Text to validate, as it does not contain a URL.");
    }
