    protected string TruncateText(object objBody)
    {
        string truncated = "";
        if (objBody != null)
        {
            truncated = objBody.ToString().Length > 50 ? 
                objBody.ToString().Substring(0, 47) + "..." : objBody.ToString();
        }
        return truncated;
    }
    protected string GetSenderNameFromID(object objSenderID)
    {
        string senderName = "";
        if (objSenderID != null)
        {
            senderName = CallDatabaseToGetNameFromID();
        }
        return senderName;
    }
    private string CallDatabaseToGetNameFromID()
    {
        //implement your database call to retrieve sender name from id
        throw new NotImplementedException();
    }
