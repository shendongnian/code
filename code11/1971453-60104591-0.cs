csharp
public class RootObject
{
    [JsonProperty("content")]
    public Content[] Contents { get; set; }
}
public class Content
{
    [JsonProperty("Id")]
    public string Id { get; set; }
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
               new RootObject
               {
                   Contents = new[]
                   {
                       new Content
                       {
                           Id = "00001",
                           ENumber = "no",
                           IsOwner = false,
                           IsAlone = false
                       },
                       new Content
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
public async Task PerformingAction_WithCriteria_ReturnsExpectedThing(RootObject rootObject)
{
    // Arrange
    // Serialize RootObject to create a string
    var rootObjectAsString = JsonConvert.SerializeObject(rootObject);
    // Create the StringContent object to post to the server, with a content type set
    var stringContent = new StringContent(rootObjectAsString, System.Text.Encoding.UTF8, "application/json");
    // Create a HttpClient whose BaseAddress is the host address
    var httpClient = new HttpClient { BaseAddress = new Uri("http://something.com") };
    // Act
    // Post the data to a URL that's relative to the base address
    var response = await httpClient.PostAsync("relative/api/url/path", stringContent);
    // Assert
    // Assert that a successful status code returns, you'd perform your own assertion logic here.
    Assert.True(response.IsSuccessStatusCode);
}
