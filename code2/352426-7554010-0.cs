    enum MyTypes
    {
     URL = 1,
     UserName = 2,
     Id = 3,
    }
    
    switch (myType)
    {
        case MyTypes.URL:
            TidyUrl();
        case MyTypes.UserName:
            TidyUsername();
        case MyTypes.Id:
            TidyID();
        default:
            break;
    }
