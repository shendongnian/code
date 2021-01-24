    public static class MyObservableExtensions
    {
        public static IObservable<T> UntilSubscribeReplay<T>(this IObservable<T> source) 
            => new UntilSubscribeReplay<T>(source);
    }
