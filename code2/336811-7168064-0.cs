    public IQueriable<UserDTO> GetUserAccountDetails(string UserID)
    {
        DataSet oneBazillionRows = SQLServer.GetAllUserRows();
        // LINQ to the rescue
        return from user in oneBillionRows
               where user.ID = UserID;
    }
