    public void Function1()
    {
        if(!Function2())
        {
          return;
        }
    }
    
    public bool Function2()
    {
        if (1 == 1)
        {   
            return false;  //Exit from both functions
        }
    }
