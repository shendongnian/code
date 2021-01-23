    public static class ObservableEx
    {
        public static IObservable<TSource> LogInterval(
            this IObservable<TSource> source, string message)
        {
            return source
                .TimeInterval()
                .Do(x => Debug.WriteLine("{0} :: {1} ({2})", 
                    message, x.Value, x.Interval.TotalMilliseconds);
                .RemoveTimeInteval();
        }
    }
