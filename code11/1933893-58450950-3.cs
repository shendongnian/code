    [Fact]
    public async Task Ads_Can_Searched_By_UserId() {
        //Arrange
        var validator = new Mock<IValidator<AdToSearchDto>>();
        
        var validResult = new ValidationResult();
        validator
            .Setup(_ => _.Validate(It.IsAny<ValidationContext>())
            .Returns(validResult);
        
        var adService = new AdService(validator.Object);
        //...
    }
