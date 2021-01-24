csharp
public class UserModel
{
    [JsonProperty("content")]
    public UserModelDto[] {get; set;}
}
public class UserModelDto
{
    [JsonProperty("id")]
    public string Id{ get; set; }
    [JsonProperty("eNumber")]
    public string ENumber { get; set; }
    [JsonProperty("isOwner")]
    public bool IsOwner { get; set; }
    [JsonProperty("isAlone")]
    public bool IsAlone { get; set; }
}
Add a `public static IEnumerable<object[]>` property, or method, to your test class, which also contains your test scenarios.
csharp
public static IEnumerable<object[]> TestCaseScenarios
    => new object[][]
       {
           new object[]
           {
               new UserModel
               {
                   Contents = new[]
                   {
                       new UserModelDto
                       {
                           Id = "00001",
                           ENumber = "no",
                           IsOwner = false,
                           IsAlone = false
                       },
                       new UserModelDto
                       {
                           Id = "00001",
                           ENumber = "007",
                           IsOwner = true,
                           IsAlone = true
                       },
                   }
               }
           },
           new object[] { } //etc
       }
Apply the `MemberDataAttribute` to your test
csharp
[Theory] // Tests which accept parameters require the TheoryAttribute, instead of FactAttribute
[MemberData(nameof(TestCaseScenarios))]
public async Task PerformingAction_WithCriteria_ReturnsExpectedThing(UserModel userModel)
{
    // Serialize userModelto create a string
    var userModelAsString = JsonConvert.SerializeObject(userModel);
    // Create the StringContent object
    var stringContent = new StringContent(userModelAsString);
    // Create a HttpClient whose BaseAddress is the host address
    var mockHttp = new Mock<HttpMessageHandler>(MockBehavior.Strict);
    mockHttp
        .Protected()
        .Setup<Task<HttpResponseMessage>>(
            "SendAsync",
            ItExpr.IsAny<HttpRequestMessage>(),
            ItExpr.IsAny<CancellationToken>())
        .ReturnsAsync(new HttpResponseMessage()
        {
            StatusCode = HttpStatusCode.OK,
            Content = new StringContent(stringContent)
        })
        .Verifiable();
        
    var httpClient = new HttpClient(mockHttp.Object) { BaseAddress = new Uri("http://something.com") };
}
