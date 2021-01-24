    [TestClass]
    public class SnakeCaseNamingTests {
        [TestMethod]
        public void SHould_Read_SnakeCase_Naming() {
            var tokenString = @"
            {
              ""access_token"": ""sdfsdfsdfsdfsdfds"",
              ""expires_in"": 3200
            }";
            var settings = new JsonSerializerSettings {
                ContractResolver = new DefaultContractResolver {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
            Token token = JsonConvert.DeserializeObject<Token>(tokenString, settings);
            token.Should().NotBeNull();
            token.accessToken.Should().NotBeNull();
            token.expiresIn.Should().Be(3200);
        }
        public class Token {
            public string accessToken { get; set; }
            public int expiresIn { get; set; }
            public string tokenType { get; set; }
        }
    }
