    public bool cancel = false;
    
    public void MethodRuningOnThread()
    {
       while(!cancel)
       {
          //do stuff
       }
    }
