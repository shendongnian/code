    public class TestConfig {
        [Required]
        public string SomeKey { get; set; }
        [Required] //<--NOTE THIS
        public string SomeOtherKey { get; set; }
    }
    public void Validation_Should_Fail_For_Required_Setting() {
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
        var exception = Assert.Throws<ValidationException>(act);
        //...other assertions of validation results within exception object
    }
