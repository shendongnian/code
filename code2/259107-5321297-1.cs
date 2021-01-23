    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static string[] GetCompletionList(string prefixText, int count, string contextKey)
    {
      ArrayList testList = new ArrayList();
      ...
      return (string[])testList.ToArray(typeof(string));
    }
