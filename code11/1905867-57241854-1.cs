    SomeDbContext firstContext;
    bool isSame;
    using (var scope = someServiceProvider.CreateScope()) {
       firstContext = scope.ServiceProvider.GetService<SomeDbContext>();
    }
    
    using (var scope = someServiceProvider.CreateScope()) {
       var secondContext = scope.ServiceProvider.GetService<SomeDbContext>();
       isSame = firstContext == secondContext; //should be false, right?
    }
