    public static class Scale<T>
    {
        public static Func<T, double, T> Do { get; private set; }
        static Scale()
        {
            var par1 = Expression.Parameter(typeof(T));
            var par2 = Expression.Parameter(typeof(double));
            try
            {
                Do = Expression
                    .Lambda<Func<T, double, T>>(
                        Expression.Multiply(par1, par2),
                        par1, par2)
                    .Compile();
            }
            catch
            {
                Do = Expression
                    .Lambda<Func<T, double, T>>(
                        Expression.Convert(
                            Expression.Multiply(
                                Expression.Convert(par1, typeof (double)),
                                par2),
                            typeof(T)),
                        par1, par2)
                    .Compile();
            }
        }
    }
