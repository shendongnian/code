        public static void Required<T>(Expression<Func<T>> parameter) where T : class
        {
            if (parameter.Compile().Invoke() == null)
            {
                var caller = ((MemberExpression)parameter.Body).Member.Name;
                throw new ArgumentNullException(caller);
            }
            // ...
        }
