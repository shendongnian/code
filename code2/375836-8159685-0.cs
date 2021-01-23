        public virtual string GetName<T>(Expression<Func<T>> expression)
        {
            return GetMemberName(expression);
        }
        /// <summary>Abstraction for actually finding the name of the target of the expression</summary>
        private static string GetMemberName<T>(Expression<Func<T>> expression)
        {
            if (expression != null)
            {
                var myMemberExpression = expression.Body as MemberExpression;
                if (myMemberExpression != null && myMemberExpression.Member != null)
                {
                    return myMemberExpression.Member.Name;
                }
            }
            return string.Empty;
        }
