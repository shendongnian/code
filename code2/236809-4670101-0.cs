    void myNumericUpDown_ValueChanged(object sender, EventArgs e)
    {
        // Sync up the trackbar with the value just entered in the spinbox
        myTrackBar.Value = Convert.ToInt32(myNumericUpDown.Value);
    }
    
    void myTrackBar_ValueChanged(object sender, EventArgs e)
    {
        // Sync up the spinbox with the value just set on the trackbar
        myNumericUpDown.Value = myTrackBar.Value;
    }
