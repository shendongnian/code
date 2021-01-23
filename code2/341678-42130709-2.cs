    public static class MoqExtensions
    {
        public static IReturnsResult<TMock> ReturnsInOrder<TMock, TResult, T1>(this ISetup<TMock, TResult> setup, params Func<T1, TResult>[] valueFunctions)
            where TMock : class
        {
            var queue = new Queue<Func<T1, TResult>>(valueFunctions);
            return setup.Returns<T1>(arg => queue.Dequeue()(arg));
        }
    }
