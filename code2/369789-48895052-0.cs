        private const int millisecondsToWait = 500;
        private static DateTime s_lastTimeOfTyping;
        private void SearchField_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var latestTimeOfTyping = DateTime.Now;
            var text = ((TextBox)sender).Text;
            Task.Run(()=>DelayedCheck(latestTimeOfTyping, text));
            s_lastTimeOfTyping = latestTimeOfTyping;
        }
        private async Task DelayedCheck(DateTime latestTimeOfTyping, string text)
        {
            await Task.Delay(millisecondsToWait);
            if (latestTimeOfTyping.Equals(s_lastTimeOfTyping))
            {
                // Execute your function here after last text change
                // Will need to bring back to the UI if doing UI changes
            }
        }
