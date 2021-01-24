    public bool FirstThing
    {
        get => (_bottom64bits & 0x01) == 1;
        set
        {
            //set or clear the 0 bit
            if (value)
            {
                _bottom64bits |= 1ul;
            }
            else
            {
                _bottom64bits &= (~1ul);
            }
        }
    }
