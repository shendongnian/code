    object myLock = new object();
    bool stopProcessing = false;
    
    public Double? Run(int n)
    {
        int i = 0;
        while (i < n)
        {
            lock(myLock)
            {
                if(stopProcessing)
                    break;
            }
            // here goes the heavy computation thing
            // and I need to read some "inputkey" as well to break this loop
            i++;
        }
    }
