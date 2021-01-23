    static void HandlePrimitive(Expression e) {
      // TODO: Handle primitive cases (>, <, <=, !=, >=, ..)
      Console.WriteLine(e.NodeType);
    }
    static void Process(Expression e) {
      if (e.NodeType == ExpressionType.OrElse)
      {
        // Process left subexpression (one (in)equality) as primitive
        // and right subexpression recursively (it may be either primitive 
        // or another OrElse node.
        var be = e as BinaryExpression;
        HandlePrimitive(be.Left);
        Process(be.Right);
      }
      else HandlePrimitive(e);
    }
    Expression<Func<Product,bool>> f = a => a.ProductType == "tea" || a.Price <= 5;
    Process(f.Body);
