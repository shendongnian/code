    public static class Observer
    {
        /// <summary>
        /// Merges two observable sequences into one observable sequence by using the selector function 
        /// whenever the first observable produces an element rigth before the second one.
        /// </summary>
        /// <param name="first"> First observable source.</param>
        /// <param name="second">Second observable source.</param>
        /// <param name="resultSelector">Function to invoke whenever the first observable produces an element rigth before the second one.</param>
        /// <returns>
        /// An observable sequence containing the result of combining elements of both sources 
        /// using the specified result selector function.
        /// </returns>
        public static IObservable<TResult> Before<TLeft, TRight, TResult>(this IObservable<TLeft> first, IObservable<TRight> second, Func<TLeft, TRight, TResult> resultSelector)
        {
            var result = new Subject<TResult>();
            bool firstCame = false;
            TLeft lastLeft = default(TLeft);
            first.Subscribe(item =>
            {
                firstCame = true;
                lastLeft = item;
            });
            second.Subscribe(item =>
            {
                if (firstCame)
                    result.OnNext(resultSelector(lastLeft, item));
                firstCame = false;
            });
            return result;
        }
        /// <summary>
        /// Merges an observable sequence into one observable sequence by using the selector function 
        /// every time two items came from <paramref name="first"/> without any item of any observable
        /// in <paramref name="second"/>
        /// </summary>
        /// <param name="first"> Observable source to merge.</param>
        /// <param name="second"> Observable list to ignore.</param>
        /// <param name="resultSelector">Function to invoke whenever the first observable produces two elements without any of the observables in the secuence produces any element</param>
        /// <returns>
        /// An observable sequence containing the result of combining elements
        /// using the specified result selector function.
        /// </returns>
        public static IObservable<TResult> Without<TLeft, TResult>(this IObservable<TLeft> first,  Func<TLeft, TLeft, TResult> resultSelector,params IObservable<object>[] second)
        {
            var result = new Subject<TResult>();
            
            bool firstCame = false;
            TLeft lastLeft = default(TLeft);
            first.Subscribe(item =>
            {
                if (firstCame)
                    result.OnNext(resultSelector(lastLeft, item));
                firstCame = true;
                lastLeft = item;
            });
            foreach (var observable in second)
                observable.Subscribe(item => firstCame = false);
            return result;
        }        
    }
