        public class SwapVisitor : ExpressionVisitor
        {
            public Expression From { get; set; }
            public Expression To { get; set; }
        
            public override Expression Visit(Expression node)
            {
                return node == From ? To : base.Visit(node);
            }
        }
