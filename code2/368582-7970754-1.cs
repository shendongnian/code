    TimeSpan remainingTime=endTime-DateTime.UtcNow;
    if(remainingTime<0)
    {
       label1.Text = "Done!";
       timer1.Enabled=false; 
    }
    else
    {
      label1.Text = remainingTime.ToString();
    }
