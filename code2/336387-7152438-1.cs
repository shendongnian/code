    WsWWDAPI.WAPI m_WAPIObj = null;
    WsWWDAPI.Credential m_Crededential = null;
    public void Init()
    {
        m_WAPIObj = new WsWWDAPI.WAPI();
        m_Crededential = new WsWWDAPI.Credential();
        m_Crededential.Account  = "account";
        m_Crededential.Password = "password";
    }
    public void CallDescribe()
    {
        String sReturnXml;
        String sCLTRID = System.Guid.NewGuid().ToString();
        sReturnXml = m_WAPIObj.Describe(sCLTRID, m_Crededential);
        Console.WriteLine( sReturnXml );
    }
    static void Main(string[] args)
    {
        ResellerAPI reseller = new ResellerAPI();
        reseller.Init();
        reseller.CallDescribe();
    }
