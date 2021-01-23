    public static class ObservableExtensions
    {
        public static IObservable<T> SampleFirst<T>(
            this IObservable<T> source,
            TimeSpan sampleDuration,
            IScheduler scheduler = null)
        {
            scheduler = scheduler ?? Scheduler.Default;
            var sourcePub = source.Publish().RefCount();
            return sourcePub.Window(() => sourcePub.Delay(sampleDuration,scheduler))
                            .SelectMany(x => x.Take(1));
        }
    }
