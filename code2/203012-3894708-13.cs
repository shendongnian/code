        private Car lambda0(Car c)
        {
            return c;
        }
        private Func<Car, Car> CachedAnonymousMethodDelegate1;
        public static void Main()
        {
            if (CachedAnonymousMethodDelegate1 == null)
                CachedAnonymousMethodDelegate1 = new Func<Car, Car>(lambda0);
            var query = db.Cars.Select<Car, Car>(CachedAnonymousMethodDelegate1);
            foreach // ...
        }
    In reality the method is not called `lambda0` but something like `<Main>b__0` (where `Main` is the name of the containing method). Similarly, the cached delegate is actually called `CS$<>9__CachedAnonymousMethodDelegate1`.
    If you are using LINQ-to-SQL, then `db.Cars` will be of type `IQueryable<Car>` and this step is very different. It would instead turn the lambda expression into an expression tree:
        public static void Main()
        {
            var parameter = Expression.Parameter(typeof(Car), "c");
            var lambda = Expression.Lambda<Func<Car, Car>>(parameter, new ParameterExpression[] { parameter }));
            var query = db.Cars.Select<Car, Car>(lambda);
            foreach // ...
        }
