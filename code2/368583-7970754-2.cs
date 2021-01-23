    TimeSpan remainingTime=endTime-DateTime.UtcNow;
    if(remainingTime<TimeSpan.Zero)
    {
       label1.Text = "Done!";
       timer1.Enabled=false; 
    }
    else
    {
      label1.Text = remainingTime.ToString();
    }
