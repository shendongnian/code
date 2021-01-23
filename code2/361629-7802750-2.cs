    [WebMethod]
    public  string IsRowChanged(int en_id , string ts)
    {
        byte[] timestamp = Encoding.UTF8.GetBytes(ts);
        // rest of your function here
    }
