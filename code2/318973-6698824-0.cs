    class TypeChangeVisitor : ExpressionVisitor
    {
        private readonly Type from, to;
        private readonly Dictionary<Expression, Expression> substitutions;
        public TypeChangeVisitor(Type from, Type to, Dictionary<Expression, Expression> substitutions)
        {
            this.from = from;
            this.to = to;
            this.substitutions = substitutions;
        }
        public override Expression  Visit(Expression node)
        { // general substitutions (for example, parameter swaps)
            Expression found;
            if(substitutions != null && substitutions.TryGetValue(node, out found))
            {
                return found;
            }
     	    return base.Visit(node);
        }
        protected override Expression VisitMember(MemberExpression node)
        { // if we see x.Name on the old type, substitute for new type
            if (node.Member.DeclaringType == from)
            {
                return Expression.MakeMemberAccess(Visit(node.Expression),
                    to.GetMember(node.Member.Name, node.Member.MemberType,
                    BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Single());
            }
            return base.VisitMember(node);
        }
    }
    public class Program
    {
        public static void Main()
        {
            Expression<Func<AnimalViewModel, bool>> predicate = x => x.Name == "abc";
            var switched = Translate<AnimalViewModel, Animal>(predicate);
        }
        public static Expression<Func<TTo, bool>> Translate<TFrom, TTo>(Expression<Func<TFrom, bool>> expression)
        {
            var param = Expression.Parameter(typeof(TTo), expression.Parameters[0].Name);
            var subst = new Dictionary<Expression, Expression> { { expression.Parameters[0], param } };
            var visitor = new TypeChangeVisitor(typeof(TFrom), typeof(TTo), subst);
            return Expression.Lambda<Func<TTo, bool>>(visitor.Visit(expression.Body), param);
        }
    }
