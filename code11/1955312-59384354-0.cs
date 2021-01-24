        private void CountDown()
        {
            int timeToComplete = 5; //Time in seconds
            Thread thread = new Thread(() => {
                while (progressBar1.Value >= 0)
                {
                    progressBar1.Value -= progressBar1.Maximum / timeToComplete;
                    Thread.Sleep(1000); //Time is 1 second
                }
            });
            thread.Start();
        }
