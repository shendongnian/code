    int state = 0;
    
    // If you're using tuples...
    if(some condition)
    {
        state = someFakeEnum.Item2;
    }
    // ...or if you're using anonymous types
    if(some condition) 
    {
        state = someFakeEnum.State2;
    }
    // or you can use a switch statement like this if you're using an anonymous type:
    
        switch(state)
        {
            case someFakeEnum.State1:
                 
               break;
        
            case someFakeEnum.State2:
    
           break;
    }
