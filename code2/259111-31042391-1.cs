    [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    public static List<string> GetCompletionList(string prefixText, int count, string contextKey)
    {
        return UserControls_phonenumbersearch.GetCompletionList(prefixText, count, contextKey);
    }
