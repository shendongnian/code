        [Test]
        [Timeout(1250)]
        public void Execute()
        {
            var locker = new object();
            EventWaitHandle waitHandle = new AutoResetEvent(false);// <--
            const int numberOfEvents = 10;
            const int frequencyOfEvents = 100;
            var start = DateTime.Now;
            int progressEventCount = 0;
            IGradualOperation tester = new TestGradualOperation(numberOfEvents, frequencyOfEvents);
            var asyncExecutor = new AsynchronousOperationExecutor();
            asyncExecutor.Progressed += (s, e) =>
            {
                lock (locker)
                {
                    progressEventCount++;
                    waitHandle.Set();// <--
                }
            };
            asyncExecutor.Execute(tester);
            while (true)
            {
                waitHandle.WaitOne();// <--
                if (progressEventCount < numberOfEvents) continue;
                Assert.Pass("Succeeded after {0} milliseconds", (DateTime.Now - start).TotalMilliseconds);
            }
        }
