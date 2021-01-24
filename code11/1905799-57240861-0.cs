    protected void GetContext(Action<MyContext> test) {
        using(var scope = _factory.Server.Host.Services.CreateScope()) {
            var context = scope.ServiceProvider.GetRequiredService<MyContext>();
            test(context);
        }
    }
    
