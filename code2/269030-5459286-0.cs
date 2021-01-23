        [Test]
        public void ExpressionAppendDateTime()
        {
            ParameterExpression sbArgExpression = Expression.Parameter(typeof(StringBuilder), "sb");
            ParameterExpression dateTimeArgExpression = Expression.Parameter(typeof(DateTime), "dateTime");
            
            var appendMethod = typeof(StringBuilder).GetMethod("Append", new[] {typeof(DateTime)});
            Type t = typeof(DateTime);
            Expression arg;
            if (t.IsValueType && !t.IsPrimitive)
            {
                arg = Expression.TypeAs(dateTimeArgExpression, typeof(object));
            }
            else
            {
                arg = dateTimeArgExpression;
            }
            var call = Expression.Call(sbArgExpression, appendMethod, arg);
            
            var lambda = Expression.Lambda<Action<StringBuilder, DateTime>>(call, sbArgExpression, dateTimeArgExpression).Compile();
            var datetime = new DateTime();
            var sb = new StringBuilder();
            lambda.Invoke(sb, datetime);
        }
