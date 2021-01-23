    var value = dict[key];
    if (value.TryInvoke(20))
    {
        // do something...
    }
    else
    {
        int result;
        if (value.TryInvoke(20, out result))
        {
            // do something else...
        }
    }
