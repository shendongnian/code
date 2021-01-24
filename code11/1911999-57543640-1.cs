    class Program
    {
        static void Main(string[] args)
        {
            var mapped = entities
                .Select(MakeExpression<MyEntity, MyClass>(select1, select2, select3))
                .ToList();
        }
        // Create lambda expression 
        private static Expression<Func<TEntity, TModel>> MakeExpression<TEntity, TModel>(params Expression<Func<TEntity, object>>[] select)
        {
            var param = Expression.Parameter(typeof(TEntity));
            // Map expressions [select1, ..., selectN] with properties
            // For keeping things simple I map nth expression with nth property
            // eg. select1 with first property from MyClass
            var body = Expression.MemberInit(
                Expression.New(typeof(TModel)),
                typeof(TModel)
                    .GetProperties()
                    .Select((p, i) => Expression.Bind(p, MakeParam(param, select[i])))
                    .ToArray()
            );  
                
            return Expression.Lambda<Func<TEntity, TModel>>(body, param);
        }
        // Replace parameter from given expression with param
        // All expressions must have same MyEntity parameter
        private static Expression MakeParam<TEntity>(ParameterExpression param, Expression<Func<TEntity, object>> select)
        {
            Expression body = select.Body;
            return new ParamVisitor<TEntity>(param).Visit(body);
        }
    }
    class ParamVisitor<TEntity> : ExpressionVisitor
    {
        private readonly ParameterExpression _param;
        public ParamVisitor(ParameterExpression param)
        {
            this._param = param;
        }
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (node.Type == typeof(TEntity))
            {
                return this._param;
            }
            
            return base.VisitParameter(node);
        }
    }
