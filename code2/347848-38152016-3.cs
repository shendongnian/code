    public static class DbFunctionExpressions
    {
        private static readonly MethodInfo BinaryDummyMethodInfo = typeof(DbFunctionExpressions).GetMethod(nameof(BinaryDummyMethod), BindingFlags.Static | BindingFlags.NonPublic);
        private static bool BinaryDummyMethod(byte[] left, byte[] right)
        {
            throw new NotImplementedException();
        }
        public static Expression BinaryLessThan(Expression left, Expression right)
        {
            return Expression.LessThan(left, right, false, BinaryDummyMethodInfo);
        }
    }
