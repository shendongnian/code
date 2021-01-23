    using System;
    using System.Windows.Threading;
    namespace SL1Test
    {
        public class AutoTicker
        {
            private MainPage _page;
            private string _caption;
            public AutoTicker(string caption, MainPage page)
            {
                this._page = page;
                this._caption = caption;
                // start a timer to send back fake input
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
            void timer_Tick(object sender, EventArgs e)
            {
                _page.ProcessInput(string.Format("{0} @ {1}",
                    this._caption,
                    DateTime.Now.ToLongTimeString()));
            }
        }
    }
