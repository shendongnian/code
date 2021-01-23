    try
    { 
        var doc = Web_Document.Document as mshtml.IHTMLDocument2;
        const string keyName = @"Software\Microsoft\Internet Explorer\PageSetup";
        using (var key = Registry.CurrentUser.OpenSubKey(keyName, true))
        {
            if (key != null)
            {
                var oldFooter = key.GetValue("footer"); 
                var oldHeader = key.GetValue("header"); 
                key.SetValue("footer", ""); 
                key.SetValue("header", "");
                doc.execCommand("Print", true, null);
                key.SetValue("footer", oldFooter); 
                key.SetValue("header", oldHeader);
            }
        }
    }
    catch (Exception ex)
    {
        Log.Error(ex.Message,ex);
    }
