    // Implement a visitor
    public class ImathasVisitor: LogicalExpressionVisitor
    {
      // Result contains the imathas expression
      // after the visit.
      public StringBuilder Result = new StringBuilder();
      public override void Visit(Function function)
      {                
      }
      public override void Visit(LogicalExpression expression)
      {                
      }
      public override void Visit(TernaryExpression expression)
      {                
      }
      public override void Visit(UnaryExpression expression)
      {                
      }
      public override void Visit(Identifier identifier)
      {
        Result.AppendFormat("{{{0}}}", identifier.Name);
      }           
      public override void Visit(ValueExpression expression)
      {
        Result.AppendFormat("{{{0}}}", expression.Value);
      }
            
      public override void Visit(BinaryExpression expression)
      {                                
        switch(expression.Type)
        {
          case BinaryExpressionType.Div:
            Result.Append("\\frac{");
            expression.LeftExpression.Accept(this);
            Result.Append("}{");
            expression.RightExpression.Accept(this);
            Result.Append("}");
            break;
          case BinaryExpressionType.Plus:
            expression.LeftExpression.Accept(this);               
            Result.Append(HttpUtility.UrlEncode("+"));
            expression.RightExpression.Accept(this);                
            break;
          case BinaryExpressionType.Minus:
            expression.LeftExpression.Accept(this);               
            Result.Append("-");
            expression.RightExpression.Accept(this);                
            break;
        }                                                
      }           
    }
    static void Main(string[] args)
    {
      // Create a NCalc expression.
      NCalc.Expression e = new NCalc.Expression("x + 1/y");
      // Check for syntax errors.
      if(e.HasErrors())
      {
        Console.Out.WriteLine("Syntax error.");
        return;
      }
      // Transform the parsed expression into
      // an imathas expression.
      ImathasVisitor iv = new ImathasVisitor();
      e.ParsedExpression.Accept(iv);
      Console.Out.WriteLine(iv.Result);
    }
