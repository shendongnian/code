    public ActionResult Sample()
        {
            var wh1 = new ManualResetEvent(false);
            var wh2 = new ManualResetEvent(false);
            var wh3 = new ManualResetEvent(false);
            Task.Factory.StartNew(new Action<object>(wh =>
            {
                // DoSomething();
                var handle = (ManualResetEvent)wh;
                handle.Set();
            }), wh1);
            Task.Factory.StartNew(new Action<object>(wh =>
            {
                // DoSomething();
                var handle = (ManualResetEvent)wh;
                handle.Set();
            }), wh2);
            Task.Factory.StartNew(new Action<object>(wh =>
            {
                // DoSomething();
                var handle = (ManualResetEvent)wh;
                handle.Set();
            }), wh3);
            WaitHandle.WaitAll(new[] { wh1, wh2, wh3 });
            return View();
        }
