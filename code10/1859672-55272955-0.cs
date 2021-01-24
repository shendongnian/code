        private void Form1_Load(object sender, EventArgs e)
        {
            IObservable<string> button1Clicks =
                Observable
                    .FromEventPattern<EventHandler, EventArgs>(h => button1.Click += h, h => button1.Click -= h)
                    .Select(ep => "Button1");
            IObservable<string> button2Clicks =
                Observable
                    .FromEventPattern<EventHandler, EventArgs>(h => button2.Click += h, h => button2.Click -= h)
                    .Select(ep => "Button2");
            IDisposable subscription =
                button1Clicks
                    .Merge(button2Clicks)
                    .StartWith("None")
                    .Select(x => Observable.Timer(TimeSpan.Zero, TimeSpan.FromMilliseconds(500.0)).Select(n => x))
                    .Switch()
                    .ObserveOn(this)
                    .Subscribe(x => Console.WriteLine(x));
        }
