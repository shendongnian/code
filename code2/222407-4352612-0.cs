        private void timeOutEvent(object sender, ElapsedEventArgs e)
        {
            TicketContent.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new InvokeDelegate(TimeOutEvent));
            Console.WriteLine("TIMED OUT");
            timeOutTimer.Stop();
        }
        public delegate void InvokeDelegate();
        private void TimeOutEvent()
        {
            TicketContent.Visibility = Visibility.Visible;
        }
