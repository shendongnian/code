    public class MyVisitor<TIn, TOut> : ExpressionVisitor
    {
        private readonly Type funcToReplace;
        public MyVisitor()
        {
            funcToReplace = typeof(Func<,>).MakeGenericType(typeof(TIn), typeof(object));
        }
        // this hack taken from https://stackoverflow.com/a/2483054/4685428
        // and https://stackoverflow.com/a/1650895/4685428
        private static bool IsAnonymousType(Type type)
        {
            var markedWithAttribute = type.GetCustomAttributes(
              typeof(CompilerGeneratedAttribute)).Any();
            var typeName = type.Name;
            return markedWithAttribute
              && typeName.StartsWith("<>")
              && typeName.Contains("AnonymousType");
        }
        protected override Expression VisitNew(NewExpression node)
        {
            if (IsAnonymousType(node.Type))
            {
                var arguments = node.Arguments.Select(a => a.Type).ToArray();
                var ctor = typeof(TOut).GetConstructor(arguments);
                if (ctor != null) // can replace
                    return Expression.New(ctor, node.Arguments);
            }
            return base.VisitNew(node);
        }
        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            if (typeof(T) != funcToReplace)
                return base.VisitLambda(node);
            var p = node.Parameters.First();
            var body = Visit(node.Body);
            return Expression.Lambda<Func<TIn, TOut>>(body, p);
        }
    }
    
