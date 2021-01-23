    Timer timer = new Timer(); //maybe 500 ms elapsed period
    int mouseCount = 0;
    
    void OnMouseClick()
    {
       if(!timer.Enabled)
          //start timer
       mouseCount++;
    }
    
    void OnTimerTick()
    {
       timer.Stop();
       if(mouseCount == 1)
          //fire single mouse click event
       else if(mouseCount > 1)
          //fire double mouse click event
    }
