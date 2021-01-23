    object myLock = new object();
    bool stopProcessing = false;
    
    public Double? Run(int n)
    {
        int i = 0;
        while ((i < n) && (/* inputkey != ConsoleKey.Escape */))
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
        // I'm not worried about the return statement, as it is easy to do...
        // returns null if the user skipped the method by pressing Escape
        // returns null if the method didn't converged
        // returns the double value that the method calculated otherwise
    }
