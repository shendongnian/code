    public static class Extensions
    {
        public static TResult SafeInvoke<TModel, TResult>(this TModel model, Func<TModel, TResult> expression, TResult nullValue = default(TResult))
        {
            try
            {
                return expression(model);
            }
            catch (NullReferenceException)
            {
                return nullValue;
            }
        }
    }
