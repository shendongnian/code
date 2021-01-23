    // boxed int
    var left = Expression.Constant(5, typeof(object));
    
    // int
    var right = Expression.Constant(6, typeof(int));
    
    // More generally, you can use right.Type  instead of typeof(int)
    // if its static type is appropriate. 
    // Otherwise, you may need to unbox it too.
    var unboxedLeft = Expression.Unbox(left, typeof(int));
    var lessThanEx = Expression.LessThan(unboxedLeft, right);    
    var expression = Expression.Lambda<Func<bool>>(lessThanEx, null);
    
    // True : (int)(object)5 < 6
    bool b = expression.Compile()();
