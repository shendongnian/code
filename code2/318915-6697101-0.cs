    private bool controlledChange = false;
    public property int MyVal1
    {
        set 
        {
            _myVal1 = value;
            if(!controlledChange)
            {
                controlledChange = true;
                MyVal2 -= 1;
                controlledChange = false;
            }
        }
    }
    public property int MyVal2
    {
        set 
        {
            _myVal2 = value;
            if(!controlledChange)
            {
                controlledChange = true;
                MyVal1 += 1;
                controlledChange = false;
            }
        }
    }
