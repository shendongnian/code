    [WebMethod(EnableSession = true), ScriptMethod()]
    public static string[] GetCompletionList(string prefixText, int count, string 
        contextKey)
    { 
       var useremail = Session["useremail"] ?? null;
       //...
    }
 
