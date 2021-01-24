    timer1.Interval = 3000; // set interval to 3 seconds and then call Time Elapsed event
    timer1.Elapsed += Time_Elapsed;
    //Event
    private void Time_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
           // will be triggered in every 3 seconds
            rotateRightButton_Click(null, null);
            pictureBox1.Refresh();
            pictureBox2.Refresh();
     }
