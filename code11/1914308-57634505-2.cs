    [TestClass]
    public class CustomConfigurationTests {
        public static Dictionary<string, string> _data = new Dictionary<string, string>
                {
                    {"array:entries:0", "value0"},
                    {"array:entries:1", "value1"}
                };
        [TestMethod]
        public void Should_Bind_Array() {
            //Arrange
            IConfiguration config1 = new ConfigurationBuilder()
                .AddCustomConfig()
                .Build();
            IConfiguration config2 = new ConfigurationBuilder()
                .AddInMemoryCollection(_data)
                .Build();
            //Act
            var test1 = config1.GetSection("array").Get<ArrayExample>();
            var test2 = config2.GetSection("array").Get<ArrayExample>();
            //Assert
            test1.Entries.Should().BeEquivalentTo(test2.Entries);
        }
    }
