    public static class Utils
    {
        public static Expression<Func<TParameter, TResult>>
            CombineLambdas<TParameter, T, TResult>(
                Expression<Func<TParameter, T>> lambda1,
                Expression<Func<T, TResult>> lambda2
            )
        {
            var parameter = Expression.Parameter(typeof(TParameter));
            var lambda = Expression.Lambda(Expression.Invoke(lambda2,
                Expression.Invoke(lambda1, parameter)), parameter);
            return (Expression<Func<TParameter, TResult>>) lambda;
        }
    }
    public bool MakePayment(TPayment payment,
                            Expression<Func<TParcel, int>> parcelIdExpr)
    {
        ParcelRepository.Get(Utils.CombineLambdas(
            parcelIdExpr, parcelId => parcelId == 2));
    }
