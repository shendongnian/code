    class CustomExpressionWalker<TSource> : ExpressionVisitor
    {
        protected override Expression VisitMemberAccess(MemberExpression m)
        {
            if (m.Member.DeclaringType != typeof(TSource))
            {
                // We are accessing a member/variable on a class
                // We need to descend the tree through the navigation properties and eventually derive a constant expression
                return this.VisitMemberAccess(m, m.Type);
            }
            throw new NotImplementedException();
        }
        protected Expression VisitMemberAccess(MemberExpression m, Type expectedType)
        {
            if (m.Expression.NodeType == ExpressionType.Constant)
            {
                // We are at the end of the member expression 
                // i.e. MyClass.Something.Something.Value <-- we're at the Value part now
                ConstantExpression constant = (ConstantExpression)m.Expression;
                return Expression.Constant(m.Expression.Type.GetFields().Single(n => n.FieldType == expectedType && m.Member.Name.Contains(n.Name)).GetValue(constant.Value));
            }
            else if (m.Member.DeclaringType == typeof(TSource))
            {
                // I'm unsure of your current implementation but the original Member access
                // regarding serializing the expression, but if the code reaches here a nested
                // MemberAccess has landed on a Property/variable of type TSource, so you'll need
                // to decide whether to serialize here or not.  For example, if TSource was of 
                // type "myClass", it could be 
                // (myOtherClass x) => x.myClass
                throw new NotImplementedException();
            }
            else if (m.Member.DeclaringType == typeof(Nullable))
            {
                // never got round to implementing this as we don't need it yet
                // if you want to deal with Nullable<T> you're going to have to 
                // examine the logic here
                throw new NotImplementedException();
            }
            else
            {
                // continue walking the member access until we derive the constant
                return this.VisitMemberAccess((MemberExpression)m.Expression, expectedType);
            }
        }
    }	
