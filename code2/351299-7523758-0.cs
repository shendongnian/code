    public DataTable ValidateUser(string username, string password, out int result)
    {
        result = 0;
        try
        {
            //Calls the Data Layer (Base Class)
        if (objDL != null)
        {
            int intRet = 0;
            sqlDT = objDL.ValidateUser(username, password, out intRet);
            result = intRet;
        }
    //....
