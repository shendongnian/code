    // optionally or additionally put in a class<T> to capture the object type once
    // and then you don't have to repeat it if you have a lot of properties
    public Action<T, TProperty> GetSetter<T, TProperty>(
       Expression<Func<T, TProperty>> pExpression
    ) {
       var parameter1 = Expression.Parameter(typeof(T));
       var parameter2 = Expression.Parameter(typeof(TProperty));
       // turning an expression body into a PropertyInfo is common enough
       // that it's a good idea to extract this to a reusable method
       var member = (MemberExpression)pExpression.Body;
       var propertyInfo = (PropertyInfo)member.Member;
       // use the PropertyInfo to make a property expression
       // for the first parameter (the object)
       var property = Expression.Property(parameter1, propertyInfo);
       // assignment expression that assigns the second parameter (value) to the property
       var assignment = Expression.Assign(property, parameter2);
       // then just build the lambda, which takes 2 parameters, and has the assignment
       // expression for its body
       var setter = Expression.Lambda<Action<T, TProperty>>(
          assignment,
          parameter1,
          parameter2
       );
       return setter.Compile();
    }
