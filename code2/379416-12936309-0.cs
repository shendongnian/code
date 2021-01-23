        private Case[] getItems(Expression<Func<Case, bool>> exp)
        {
            return repository.Where(AddGlobalFilters(exp).Compile()).ToArray();
        }
        private Expression<Func<Case, bool>> AddGlobalFilters(Expression<Func<Case, bool>> exp)
        {
            // get the global filter
            Expression<Func<Case, bool>> newExp = c => c.CaseStatusId != (int)CaseStatus.Finished;
            // get the visitor
            var visitor = new ParameterUpdateVisitor(newExp.Parameters.First(), exp.Parameters.First());
            // replace the parameter in the expression just created
            newExp = visitor.Visit(newExp) as Expression<Func<Case, bool>>;
            // now you can and together the two expressions
            var binExp = Expression.And(exp.Body, newExp.Body);
            // and return a new lambda, that will do what you want. NOTE that the binExp has reference only to te newExp.Parameters[0] (there is only 1) parameter, and no other
            return Expression.Lambda<Func<Case, bool>>(binExp, newExp.Parameters);
        }
        /// <summary>
        /// updates the parameter in the expression
        /// </summary>
        class ParameterUpdateVisitor : ExpressionVisitor
        {
            private ParameterExpression _oldParameter;
            private ParameterExpression _newParameter;
            public ParameterUpdateVisitor(ParameterExpression oldParameter, ParameterExpression newParameter)
            {
                _oldParameter = oldParameter;
                _newParameter = newParameter;
            }
            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (object.ReferenceEquals(node, _oldParameter))
                    return _newParameter;
                return base.VisitParameter(node);
            }
        }
