    using (var scope = _server.Host.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<CarDbContext>();
        context.EnsureDeleted();
        // seed test data
    }
    // test code
