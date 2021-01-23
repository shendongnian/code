            Expression<Func<Customer, string>> email
                 = cust => cust.Email;
            var newValue = Expression.Parameter(email.Body.Type);
            var assign = Expression.Lambda<Action<Customer, string>>(
                Expression.Assign(email.Body, newValue),
                email.Parameters[0], newValue);
            var getter = email.Compile();
            var setter = assign.Compile();
