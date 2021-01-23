        [TestMethod]
        public void SimpleTest()
        {
            var sched = new TestScheduler();
            var subject = new Subject<Unit>();
            var observable = subject.AsObservable();
            var o = sched.CreateHotObservable(
                OnNext(210, new Unit())
                ,OnCompleted<Unit>(250)
                );
            var results = sched.Run(() =>
                                        {
                                            o.Subscribe(subject);
                                            return observable;
                                        });
            results.AssertEqual(
                OnNext(210, new Unit())
                ,OnCompleted<Unit>(250)
                );
        }:
