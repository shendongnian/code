        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
         public string[] GetSourceAccount(string prefixText, int count)
         {
      List<string> lstSimilarSource = new List<string>();
      //Service call and populating the string
      lstSimilarSource = Autocomplete.GetSimilarSource(prefixText, "ACCOUNT");
       return lstSimilarSource.ToArray();
        }
