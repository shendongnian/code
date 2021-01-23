    var parameters = new Dictionary<string, object>
    {
        { "?FirstName", "Josef" }, 
        { "?LastName", "Stalin" }
    };
    MyConnection.MySqlLink(strConnection, strCommand, parameters, dtTable);
