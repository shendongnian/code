    [OperationContract]
    [WebGet(UriTemplate = "GetData")]
    [WebMethod]
      public string GetData() {
        try {
          var nyseTrin = 0.00M;
          var msg = string.Format("{0}", nyseTrin);
          return msg;
        } catch (Exception ex) {
          return "GetTrinData Error: " + ex.Message;
        }
      }
