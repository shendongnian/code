    public static void Show(string message)
    {
       string FinalMessage = message.Replace("'", "\\'");
       string Jvscript = "<script type=\"text/javascript\">alert('" + FinalMessage + "');</script>";
    
       Page executingpage = HttpContext.Current.CurrentHandler as Page;
    
       if (executingpage != null && !executingpage.ClientScript.IsClientScriptBlockRegistered("alert"))
       {
          executingpage.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", Jvscript);
       }
    }    
