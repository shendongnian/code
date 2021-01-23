    public string InTheBox(int x)
    {
        //switch statment to lookup log ID
        switch (x)
        {
                case 0:
                    return "Outter";
                case 1:
                    return "Inner";
                case 2:
                    return "Border";
                default:
                    throw new ArgumentOutOfRangeException("Unknown value");
        }
    
    }
