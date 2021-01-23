    public class NetworkMonitor
        {
            public event EventHandler Started;
            public event EventHandler Stopped;
            public void Start()
            {
                var handler = Started;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
            public void Stop()
            {
                var handler = Stopped;
                if (handler != null)
                    handler(this, EventArgs.Empty);
            }
        }
        [Test]
        public void StartedAndStoppedEventsShouldFireWhenStartedAndStopped()
        {
            NetworkMonitor classUnderTest = new NetworkMonitor();
            bool startedWasFired = false;
            int stoppedWasFired = 0;
            classUnderTest.Started += (o, e) => { startedWasFired = true; };
            classUnderTest.Stopped += (o, e) => { stoppedWasFired++; };
            classUnderTest.Start();
            Assert.That(startedWasFired);
            classUnderTest.Stop();
            Assert.That(stoppedWasFired, Is.EqualTo(1));
        }
