    private void ChangeStatus(string text, string color)
        {
            var timer = new System.Timers.Timer(3000);
            timer.AutoReset = false;
            timer.Elapsed += TimerTicked;
            timer.Enabled = true;
            StatusText = text;
            StatusColor = color;
        }
    private void TimerTicked(object sender, EventArgs e)
        {
            StatusColor = "Grey";
            StatusText = "";
        }
