    /// <summary>
        /// Check if value of specific field is already exist
        /// </summary>
        /// <typeparam name="E"></typeparam>
        /// <param name="fieldName">name of the Field</param>
        /// <param name="fieldValue">Field value</param>
        /// <param name="key">Primary key value</param>
        /// <returns>True or False</returns>
        public bool TrySameValueExist(string fieldName, object fieldValue, string key)
        {
            // First we define the parameter that we are going to use the clause. 
            var xParam = Expression.Parameter(typeof(E), typeof(E).Name);
            MemberExpression leftExprFieldCheck = 
    		MemberExpression.Property(xParam, fieldName);
            Expression rightExprFieldCheck = Expression.Constant(fieldValue);
            BinaryExpression binaryExprFieldCheck = 
    		MemberExpression.Equal(leftExprFieldCheck, rightExprFieldCheck);
     
            MemberExpression leftExprKeyCheck = 
    		MemberExpression.Property(xParam, this._KeyProperty);
            Expression rightExprKeyCheck = Expression.Constant(key);
            BinaryExpression binaryExprKeyCheck = 
    		MemberExpression.NotEqual(leftExprKeyCheck, rightExprKeyCheck);
            BinaryExpression finalBinaryExpr = 
    		Expression.And(binaryExprFieldCheck, binaryExprKeyCheck);
     
            //Create Lambda Expression for the selection 
            Expression<Func<E, bool>> lambdaExpr = 
    		Expression.Lambda<Func<E, bool>>(finalBinaryExpr, 
    		new ParameterExpression[] { xParam });
            //Searching ....            
            return ((IRepository<E, C>)this).TryEntity(new Specification<E>(lambdaExpr));
        }
        /// <summary>
        /// Check if Entities exist with Condition
        /// </summary>
        /// <param name="selectExpression">Selection Condition</param>
        /// <returns>True or False</returns>
        public bool TryEntity(ISpecification<E> selectSpec)
        {
            return _ctx.CreateQuery<E>("[" + typeof(E).Name + "]").Any<E>
    					(selectSpec.EvalPredicate);
        }
