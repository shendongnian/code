    // approximate representative code; not literal translation
    var ctx = new SomeContext();
    ctx.x = ... // x is actually a public instance field of SomeContext
    var param = Expression.Parameter(typeof(Foo), "obj");
    var predicate = Expression.Lambda<Func<Foo, bool>>(
         Expression.Equal(
            Expression.PropertyOrField(param, "Bar"),
            Expression.PropertyOrField(Expression.Constant(ctx), "x")
        ), param);
    
