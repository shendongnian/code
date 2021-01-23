     string[] props = null;
     var leftObject = Expression.Parameter(typeof(object), "leftObject");
     var rightObject = Expression.Parameter(typeof(object), "rightObject");
     var equal = Expression.Variable(typeof(bool), "equal");
     var lbl = Expression.Label();
     var returnTarget = Expression.Label();
    
     var body = Expression.Block
      (
       typeof(bool),
       equal,
       Expression.Assign(equal, Expression.Constant(true)),
    
       Expression.Block(
        props.Select(property =>
          Expression.IfThen(
           Expression.NotEqual(Expression.Property(leftObject, property),
                Expression.Property(rightObject, property)),
           Expression.Block(
            Expression.Assign(equal, Expression.Constant(false)),
            Expression.Goto(lbl)
           )
          )
         )
       ),
    
       Expression.Label(lbl),
       Expression.Return(returnTarget, equal, typeof(bool)),
       Expression.Label(returnTarget)
      );
