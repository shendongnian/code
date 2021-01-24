C#
        int counterValue = 0;
        CancellationTokenSource cts;
        static readonly object obj = new object();
        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            cts = new CancellationTokenSource();
            await Task.Run(() => ProcessTheWords(false), cts.Token);
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
            counterValue = 0;
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
        }
        private async void Step_Click(object sender, RoutedEventArgs e)
        {
            cts.Cancel();
            await Task.Run(() => ProcessTheWords(true));
        }
        void ProcessTheWords(bool executeOnce)
        {
            lock (obj)
            {
                for (int i = counterValue; i < listOfWords.Count; i++)
                {
                    // process the current word by fetching it from the list: 
                    // listOfWords[counterValue];
                    Thread.Sleep(1000);
                    counterValue++;
                    if (cts.IsCancellationRequested || executeOnce)
                        break;
                }
            }
        }
 
