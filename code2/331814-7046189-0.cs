    public enum CallerType {
        RedCaller, GreenCaller, BlueCaller
    }
    
    public MyResultType MyFunction(CallerType callerType)
    {
        switch (callerType) {
            case CallerType.RedCaller:
                DoRedCallerStuff();
                break;
            case CallerType.GreenCaller:
                DoGreenCallerStuff();
                break;
            case CallerType.BlueCaller:
                DoBlueCallerStuff();
                break;
            default:
                DoDefaultStuff();
                break;
        }
    }
