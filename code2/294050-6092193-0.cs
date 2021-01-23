    /// ---- ShowAlert --------------------------------
    ///     
    /// <summary>
    /// popup a message box at the client    
    /// </summary>
    /// <param name="page">A Page Object</param>
    /// <param name="message">The Message to show</param>
   
    public static void ShowAlert(Page page, String message)
    {
        String Output;
        Output = String.Format("alert('{0}');",message);
        page.ClientScript.RegisterStartupScript(page.GetType(), "Key", Output, true);
    }
