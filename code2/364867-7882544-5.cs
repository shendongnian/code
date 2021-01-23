    for(outer blah blah blah)
    {
        if (Inner(blah blah blah))
            break;
    }
    ...
    bool Inner(blah blah blah)
    {
        for(inner blah blah blah)
        {
            if (whatever)
            {
                 return true;      
            }
        }
        return false;
    }
