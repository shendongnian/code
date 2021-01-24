    private async Task btn30_Click(object sender, EventArgs e)
    {
        int hour = DateTime.Now.Hour;
        int minute = DateTime.Now.Minute;
        int second;
        do
        {
            if (5 + DateTime.Now.Second > 60)
            {
                second = (DateTime.Now.Second + 5) - 60;
            }
            else if (5 + DateTime.Now.Second == 60)
            {
                second = 0;
            }
            else
            {
                second = DateTime.Now.Second + 5;
            }
            if (sc.checkScheduleStarted() == false)
            {
                sc.Start30(hour, minute, second);
                btn30.Text = "5 second waiting";
                await Task.Delay(5000);
    //Rest of code
