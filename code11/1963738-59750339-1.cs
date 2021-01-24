    //...
    var deleteResponse = await client.DeleteUser(expectedUser.Username);
    deleteResponse.IsSuccessStatusCode.Should().BeTrue();
    Func<Task> verifyUser = async () => await client.GetUser(expectedUser.Username);
    var exceptionAssertion = await verifyUser.Should().ThrowAsync<ApiException>();
    exceptionAssertion.And.StatusCode.Should().Be(HttpStatusCode.NotFound);
    //...
