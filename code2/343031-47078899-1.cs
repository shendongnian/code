    using System;
    using System.Reactive.Subjects;
    namespace Closures {
      public class Observable {
        public IObservable<int> ObservableProperty => _subject;
        private Subject<int> _subject = new Subject<int>();
        private int n;
        public void Fire() {
          _subject.OnNext(n++);
        }
      }
    }
