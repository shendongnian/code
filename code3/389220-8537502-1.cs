    while(KeepGoing())
    {
        //Do stuff
    }
    
    bool KeepGoing()
    {
        // Check conditions for continuing
        var value = GetMyEnumValueFromDB();
        return value != MyEnum.BreakIfYouGetThis && value != MyEnum.AlsoBreakIfYouGetThis;
    }
