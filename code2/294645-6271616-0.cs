    public class ConcatHqlGenerator : BaseHqlGeneratorForMethod
    {
        public ConcatHqlGenerator()
            : base()
        {
            this.SupportedMethods = new[] 
            { ReflectionHelper.GetMethodDefinition(() => string.Concat(null, null)) };
        }
    
        public override HqlTreeNode BuildHql(MethodInfo method,
    Expression targetObject,
    ReadOnlyCollection<Expression> arguments,
    HqlTreeBuilder treeBuilder,
    IHqlExpressionVisitor visitor)
        {
            return treeBuilder.Concat(
                new[] 
                {
                    visitor.Visit(arguments[0]).AsExpression(),
                    visitor.Visit(arguments[1]).AsExpression()
                });
        }
    }
