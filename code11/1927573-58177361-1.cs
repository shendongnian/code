    public void Max25CharsTest() {
        // Arrange
        var stringBuilder = new StringBuilder("a");
        for (var i = 0; i < 24; i++) {
            stringBuilder.Append("a");
        }
        var model = new ContactRequest { DisplayName = stringBuilder.ToString() };
        var context = new ValidationContext(model);
        var results = new List<ValidationResult>();
        // Act
        var actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);
        // Assert
        Assert.IsTrue(actual, "Expects validation to pass");
        // Append characters
        stringBuilder.Append("asdf");
        model.DisplayName = stringBuilder.ToString();
        results.Clear();
        actual = Validator.TryValidateObject(model, context, results, validateAllProperties: true);
        Assert.IsFalse(actual, "Expects validation to fail"); // Fails here
    }
