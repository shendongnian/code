    private bool stickyFlag = true;
    void rb_CheckedChanged(x,y)
    {
        if (true == stickyFlag)
        {
            LoadSomeData();
            stickyFlag = false;
        }
        ....
        // rest of the code; to be executed every single time..
    }
     
