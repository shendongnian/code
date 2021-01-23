    if (sender == btn1)
    {
        Clock.Stop();
        btn1.Enabled = false; // disable the buttons after they are clicked.
    }
    
    if (sender == btn2)
    {
        Clock1.Stop();
        btn2.Enabled = false;
    }
    
    if (sender == btn3)
    {
        Clock2.Stop();
        btn3.Enabled = false;
    }
    // If all buttons are disabled then enable the Start button.
    if (!btn1.Enabled && !btn2.Enabled && !btn3.Enabled)
    {
        btn4.Enabled = true;
    }
    
    Finish();          
