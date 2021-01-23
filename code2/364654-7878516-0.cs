        private static void Main()
        {
            using (var ping = new Ping())
            using (var waiter = new EventWaitHandle(false, EventResetMode.ManualReset))
            {
                var options = new PingOptions { DontFragment = true };
                var now = DateTime.Now;
                var data = now.ToLongDateString() + " " + now.ToLongTimeString();
                var buffer = Encoding.ASCII.GetBytes(data);
                const int Timeout = 120;
                ping.PingCompleted += PingCompleted;
                ping.SendAsync("www.speedtest.net", Timeout, buffer, options, waiter);
                waiter.WaitOne();
            }
            Console.ReadLine();
        }
        /// <summary>
        /// Handles the Ping Completed event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Net.NetworkInformation.PingCompletedEventArgs"/> instance containing
        /// the event data.</param>
        private static void PingCompleted(object sender, PingCompletedEventArgs e)
        {
            if (e.Reply.Status == IPStatus.Success)
            {
                Console.WriteLine("Address: {0}", e.Reply.Address);
                Console.WriteLine("RoundTrip time: {0}", e.Reply.RoundtripTime);
                Console.WriteLine("Time to live: {0}", e.Reply.Options.Ttl);
                Console.WriteLine("Don't fragment: {0}", e.Reply.Options.DontFragment);
                Console.WriteLine("Buffer size: {0}", e.Reply.Buffer.Length);
                Console.WriteLine("Buffer: {0}", Encoding.ASCII.GetString(e.Reply.Buffer));
            }
            else if (e.Error != null)
            {
                Console.WriteLine(e.Error);
            }
            var waitHandle = e.UserState as EventWaitHandle;
            if (waitHandle != null)
            {
                waitHandle.Set();
            }
        }
