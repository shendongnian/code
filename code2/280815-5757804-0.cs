    [WebGet(UriTemplate = "GetMyData?User={User}&Password={Password}", ResponseFormat = WebMessageFormat.Json)]
    public MyReturnObj getMyData(string User = "", string Password = "")
    {
        MyReturnObj ro = new MyReturObj()
        {
              MyField1 = @"somethign",
              MyField2 = @"more things"
        }
    
        return ro;
    }
