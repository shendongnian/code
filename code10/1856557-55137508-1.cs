    public class TestConfig {
        [Required]
        public string SomeKey { get; set; }
        [Required] //<--NOTE THIS
        public string SomeOtherKey { get; set; }
    }
    //...
    [Fact]
    public void Should_Fail_Validation_For_Required_Key() {
        //Arrange
        var inMemorySettings = new Dictionary<string, string>
        {
            {"Email:SomeKey", "value1"},
            //{"Email:SomeOtherKey", "value2"}, //Purposely omitted for required failure
            //...populate as needed for the test
        };
        IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();
            
        //Act
        Action act = () => configuration.GetSection("Email").GetValid<TestConfig>();
        
        //Assert
        ValidationException exception = Assert.Throws<ValidationException>(act);
        //...other assertions of validation results within exception object
    }
