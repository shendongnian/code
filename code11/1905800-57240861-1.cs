    [Theory]
    [InlineData("/values/sample")]
    public async Task Sample_WhenCreatingSampleData_ThenIsAddedToDatabase(string url) {
        // given
        var command = new AddSampleCommand { Name = "TestRecord" };
        // when
        var httpResponse = await Client.PostAsJsonAsync(url, command);
        // then
        httpResponse.EnsureSuccessStatusCode();
        GetContext(dbContext => {
            var item = dbContext.Samples.FirstOrDefault(x => x.Name == "TestRecord");
            item.ShouldNotBeNull();
        });
    }
    
