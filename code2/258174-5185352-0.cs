    public struct TheStruct 
    { 
        public string pageTitle; 
        public int contentID, 
        public int nodeID; 
    }
    [System.Web.Services.WebMethod]
    public static TheStruct EditPage(string nodeID)
    ....
