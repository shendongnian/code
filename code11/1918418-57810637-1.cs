    [TestMethod]
    public void Test_ParentValidator_WithMockedChildValidator() {
        var child = Substitute.For<IChild>();
        var childValidator = Substitute.For<IValidator<IChild>>();
        var parent = Substitute.For<IParent>();
        var validator = new ParentValidator(childValidator);
        parent.Child.Returns(null as IChild);
        validator.Validate(parent).IsValid.Should().BeTrue();
        parent.Child.Returns(child);
        var failedResult = new ValidationResult(new List<ValidationFailure> { new ValidationFailure("property", "message") });
        childValidator.Validate(Arg.Any<ValidationContext>()).Returns(failedResult);
        validator.Validate(parent).IsValid.Should().BeFalse();
        var validResult = new ValidationResult();
        childValidator.Validate(Arg.Any<ValidationContext>()).Returns(validResult);
        validator.Validate(parent).IsValid.Should().BeTrue();
    }
