    Expression<Func<int, int>> fn = x => x * x;
    var visitor = new JsExpressionVisitor();
    visitor.Visit(fn);
    Console.WriteLine(visitor.JavaScriptCode);
    ...
    class JsExpressionVisitor : ExpressionVisitor
    {
        private readonly StringBuilder _builder;
        public JsExpressionVisitor()
        {
            _builder = new StringBuilder();
        }
        public string JavaScriptCode
        {
            get { return _builder.ToString(); }
        }
        public override Expression Visit(Expression node)
        {
            _builder.Clear();
            return base.Visit(node);
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            _builder.Append(node.Name);
            base.VisitParameter(node);
            return node;
        }
        protected override Expression VisitBinary(BinaryExpression node)
        {
            base.Visit(node.Left);
            _builder.Append(GetOperator(node.NodeType));
            base.Visit(node.Right);
            return node;
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            _builder.Append("function(");
            for (int i = 0; i < node.Parameters.Count; i++)
            {
                if (i > 0)
                    _builder.Append(", ");
                _builder.Append(node.Parameters[i].Name);
            }
            _builder.Append(") {");
            if (node.Body.Type != typeof(void))
            {
                _builder.Append("return ");
            }
            base.Visit(node.Body);
            _builder.Append("; }");
            return node;
        }
        private static string GetOperator(ExpressionType nodeType)
        {
            switch (nodeType)
            {
                case ExpressionType.Add:
                    return " + ";
                case ExpressionType.Multiply:
                    return " * ";
                case ExpressionType.Subtract:
                    return " - ";
                case ExpressionType.Divide:
                    return " / ";
                case ExpressionType.Assign:
                    return " = ";
                case ExpressionType.Equal:
                    return " == ";
                case ExpressionType.NotEqual:
                    return " != ";
                // TODO: Add other operators...
            }
            throw new NotImplementedException("Operator not implemented");
        }
    }
