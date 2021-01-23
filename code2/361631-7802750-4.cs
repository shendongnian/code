    [WebMethod]
    public  string IsRowChanged(int en_id , string ts)
    {
        byte[] timestamp = Encoding.ASCII.GetBytes(ts);
        // rest of your function here
    }
