    public void Function1()
    {
        if (Function2() == false)
            return;
        
        // do other code if Function2 succeeded
    }
    public bool Function2()
    {
        if (1 == 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
