    public void AddressValidator_adds_postal_code_errors()
    {
        var postalCodeError = new ValidationResult();
        postalCodeError.AddError("Bad!");
        postalCodeError.AddError("Worse!");
        var postalCodeValidatorMock = new Mock<IPostalCodeValidator>();
        postalCodeValidatorMock.Setup(x => x.ValidatePostalCode(It.IsAny<Address>()))
            .Returns(postalCodeError);
        var subject = new AddressValidator(postalCodeValidatorMock.Object);
        var result = subject.ValidateAddress(new Address());
        Assert.IsTrue(result.Errors.Contains("Bad!"));
        Assert.IsTrue(result.Errors.Contains("Worse!"));
    }
