    var a = await MyStatePropertyAccessor.GetAsync(turnContext);
    a.Foo = "Some value";
    // await MyStatePropertyAccessor.SetAsync(turnContext, a); // <- You don't need this
    var b = await MyStatePropertyAccessor.GetAsync(turnContext); // This will be the same as a
    turnContext.SendActivityAsync(b.Foo); // Some value
