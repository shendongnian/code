    //timer tick handler. All movement takes place here.
    void moveTimer_Tick(object sender, EventArgs e)
    {
        // Do not update if movement is paused
        if(paused) {
           return;
        }
        ...
    }
