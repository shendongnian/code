    private object GetGlobalVariable(WebBrowser browser, string variable)
    {
        string[] variablePath = variable.Split('.');
        int i = 0;
        object result = null;
        string variableName = "window";
        while  (i < variablePath.Length)
        {
            variableName = variableName + "." + variablePath[i];
            result = browser.Document.InvokeScript("eval", new object[] { variableName });
            if (result == null)
            {
                return result;
            }
            i++;
        }
        return result;
    }
