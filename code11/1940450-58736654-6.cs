    using ILifetimeScope childScope = scope.BeginLifetimeScope(b => {
        b.Register<XContext>(c => scope.Resolve<XContext>()).ExternallyOwned(); 
    });
    var operation = childScope.Resolve<IOperation>();
    operation.Do();
