     private void Get_Attitude()
        //gets the current yaw, pitch, roll in degrees, and displays
    {
        var attitude = vn100.CurrentAttitude;
        yaw.Text = Convert.ToString(attitude.Ypr.YawInDegs);
        pitch.Text = Convert.ToString(attitude.Ypr.PitchInDegs);
        roll.Text = Convert.ToString(attitude.Ypr.RollInDegs);
        vn100.CurrentAttitude = null;
    }
    private void getAtr_Click(object sender, EventArgs e)
    {
    for (int i = 1; i <= 10; i++)
    {
        while (vn100.CurrentAttitude == null)
            Thread.Sleep(10);
        Get_Attitude();
        Application.DoEvents();
    }
    }
