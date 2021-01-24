    // …
    httpResponse.EnsureSuccessStatusCode();
    using (var scope = Host.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetService<MyContext>();
        var item = dbContext.Samples.FirstOrDefault(x => x.Name == "TestRecord");
        item.ShouldNotBeNull();
    }
