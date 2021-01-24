    private void timer2_Tick(object sender, EventArgs e)
    {
        //Take image and analyse for radius
        Capture_Image();
        Measure_Circle();
        //stop timer
        timer2.Stop();
        //Same code as when button13 is clicked
        DateTime Start = DateTime.Now;
        DateTime Ende;
        if(DateTime.Now.ToString("tt") == "AM")
        {
            Ende = new DateTime(Start.Year, Start.Month, Start.Day, 12, 20, 0);
        }
        else
        {
            Ende = new DateTime(Start.Year, Start.Month, Start.Day + 1, 0, 20, 0);
        }
        int dauer = (int)(Ende - Start).TotalMilliseconds;
        label32.Text = DateTime.Now.AddMilliseconds(dauer+100).ToString();
        label28.Text = DateTime.Now.ToString();
        timer2.Interval = dauer;
        timer2.Start();
    }
