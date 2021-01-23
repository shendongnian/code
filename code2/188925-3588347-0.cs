    public bool foo(param)
    {
        switch (param)
        {
            case 1:
                return MethodForParamEqualOne();
            default:
                throw new ArgumentException("Param value=" + param + " is not supported.");
        }
        //If you're doing stuff here, the method is likely doing too much.
    }
