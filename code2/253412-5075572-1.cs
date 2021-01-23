            Expression<Func<Customer, string>> email
                 = cust => cust.Email;
            var newValue = Expression.Parameter(email.Body.Type);
            var assign = Expression.Lambda<Action<Customer, string>>(
                Expression.Assign(email.Body, newValue),
                (ParameterExpression)((MemberExpression)email.Body).Expression, newValue);
            var getter = email.Compile();
            var setter = assign.Compile();
