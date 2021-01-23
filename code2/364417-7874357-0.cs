    public abstract class Expression
    {
        List<Expression> linkedExpressions;
        protected Expression lhs; // left hand side, right hand side
        protected Expression rhs;
        
        protected Expression(Expression x, Expression y)
        {
            List<Expression> linkedExpressions = new List<Expression>();
            lhs = x;
            rhs = y;
            // let the expressions know that they have a expression dependant on them
            lhs.NotifyExpressionLinked(this); 
            rhs.NotifyExpressionLinked(this);
        }
        
        private void NotifyExpressionLinked(Expression e)
        {
            if (e != null)
            {
                linkedExpressions.Add(e);
            }
        }
        
        private void NotifyExpressionUnlinked(Expression e)
        {
            if (linkedExpressions.Contains(e)
            {
                linkedExpressions.Remove(e);
            }
        }
        // this method will notify all subscribed expressions that
        // one of the values they are dependant on has changed
        private void NotifyExpressionChanged()
        {
            if (linkedExpressions.Count != 0) // if we're not a leaf node
            {
                foreach (Expression e in linkedExpressions)
                {
                    e.NotifyExpressionChanged();
                }
            }
            else Evaluate() 
            // once we're at a point where there are no dependant expressions 
            // to notify we can start evaluating
        }
        
        // if we only want to update the lhs, y will be null, and vice versa
        public sealed void UpdateValues(Expression x, Expression y)
        {
            if (x != null)
            {
                lhs.NotifyExpressionUnlinked(this);
                x.NotifyExpressionLinked(this);
                lhs = x;
            }
            
            if (y != null)
            {
                rhs.NotifyExpressionUnlinked(this);
                y.NotifyExpressionLinked(this);
                rhs = y;
            }
            
            NotifyExpressionChanged();
        }
        
        public virtual float Evaluate()
        {
            throw new NotImplementedException(); // we expect child classes to implement this
        }
    }
