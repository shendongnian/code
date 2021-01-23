    public void Add(int intProp)
    {
        var current = intPropSetCount++;
        switch(current)
        {
            case 0: Padding = intProp; return;
            case 1: SecondProp = intProp; return;
            // ...
            default: throw new Exception();
        }
    }
