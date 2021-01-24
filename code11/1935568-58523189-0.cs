    private static int Convert(int OldMax, int OldMin, int NewMax, int NewMin, int OldValue)
    {
       int NewValue = 0;
       int NewRange = 0;
       int OldRange = 0;
    
        OldRange = (OldMax - OldMin);
        if (OldRange == 0)
        NewValue = NewMin;
        else
        {
           NewRange = (NewMax - NewMin);
           NewValue = (((OldValue - OldMin) * NewRange) / OldRange) + NewMin;
        }
    
        return NewValue;
    }
