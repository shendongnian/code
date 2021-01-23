    public class DataImporter {
        private Subject<string> _StatusSubject = new Subject<string>();
        public IObservable<string> Status { get { return _StatusSubject; }
        ...
    }
