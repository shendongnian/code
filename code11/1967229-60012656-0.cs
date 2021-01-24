    [Theory]
    [InlineData("Valid", true)]
    [InlineData("Not valid", false)]
    public void ShouldValidateName(string name, bool expected) 
    {
        var entity = new DomainEntity(name);
        
        var isValid = new EntityNameChecker().IsDomainEntityNameValid(entity);
        isValid.Should().Be(expected); // Pass
    }
