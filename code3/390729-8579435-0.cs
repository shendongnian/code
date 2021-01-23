    var currentDbVersion = GetDbVersion();
    while(currentDbVersion < currentCodeVersion)
    {
        switch(currentDbVersion)
        {
            case 1.2:
                RunUpgradeFrom12to13();
                break;
            case 1.3:
                RunUpgradeFrom12to13();
                break;
            default:
                break;
        }
        currentDbVersion = GetDbVersion();
    }
