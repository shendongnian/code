    object _LockObj = new object();
    int _counter = 0;
    
    void Event_Handler(object sender, EventArgs e)
    {
        MyObject originator = sender as MyObject;
        if(originator == null)
            return;
    
        *Do stuff with the originator*
    
        lock(_LockObj)
        {
            ++_counter;
            if (_counter == ListOfMyObjects.Count)
            {
                *Proceed*
                
                _counter = 0;
            }
        }
    }
