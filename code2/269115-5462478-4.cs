        public static IObservable<Unit> StreamToFile(this Tuple<Stream, string> source)
        {
            return Observable.Defer(() =>
                source.Item1.AsyncRead().WriteTo(File.Create(source.Item2)));
        }
