        private Car lambda0(Car c)
        {
            return c;
        }
        private Func<Car, Car> CachedAnonymousMethodDelegate1;
        public static void Main()
        {
            if (CachedAnonymousMethodDelegate1 == null)
                CachedAnonymousMethodDelegate1 = new Func<Car, Car>(lambda0);
            var query = db.Cars.Select(CachedAnonymousMethodDelegate1);
            foreach(Car aCar in query)
            {
                 Console.WriteLine(aCar.Name);
            }
        }
    This assumes that `db.Cars` is of type `IEnumerable<Car>`. If you are using LINQ-to-SQL, then it will be `IQueryable<Car>` and this step is very different. It would instead turn the lambda expression into an expression tree, which in this case is a sequence of calls to `Expression.Parameter` and `Expression.Lambda`. I will continue assuming that it’s `IEnumerable<Car>`.
