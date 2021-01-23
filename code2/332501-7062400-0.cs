    public event Action doLoadSomeData; 
    void onLoad(sender, args)
    {
        doLoadSomeData += LoadSomeData();
    }
    void rb_CheckedChanged(x, y)
    {
        if (doLoadSomeData != null)
        {
             doLoadSomeData(); //need to load only once.
        }
        doLoadSomeData = null;
        // rest of the code; to be executed every single time..
    }
