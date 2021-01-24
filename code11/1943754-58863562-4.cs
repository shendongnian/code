    bool _oldSignal;
    private void timer3_Tick(object sender, EventArgs e)
    {
        chksignal_robot(); //keep checking signal    
        
        var newSignal = textBox8.Text.Contains("process");
        var isRisingEdge = newSignal && (_oldSignal == false);
        _oldSignal = newSignal;
    
        if (isRisingEdge) //
        {
            totalsheetcount++;
    
            grab_image();
            Thread.Sleep(200);
            processimage();
        }
    }
