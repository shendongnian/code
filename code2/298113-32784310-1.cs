        [Test]
        public void ShouldNackUnparsableInboundMessage()
        {   
            var nackCalled = false;
            _mock.Setup(m => m.BasicNack(999, false, false)).Callback(() =>
            {
                nackCalled = true;
            });
            ... do whatever which invokes the call on another thread.
            WaitFor(() => nackCalled);
            // Test will fail with timeout if BasicNack is never called.
        }
