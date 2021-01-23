    public void MyButtonClick(object sender, EventArgs e)
    {
        if (sender == btn1)
        {
            Clock.Stop();
        }
        if (sender == btn2)
        {
            Clock1.Stop();
        }
        if (sender == btn3)
        {
            Clock2.Stop();
        }
        Finish();
       if (!Clock.Enabled && !Clock1.Enabled && !Clock2.Enabled) btn4.Enabled = true;
    }
