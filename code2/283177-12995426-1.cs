    public static void ShowMSG(string msg,object objPage)
    {
        string sj = "<script>" +
            " alert('" + msg + "')" +
            " </script>";       
        System.Web.UI.Page pg = (System.Web.UI.Page)objPage;
        pg.ClientScript.RegisterStartupScript(objPage.GetType(), "onload", sj);
    }
    //where object is the page object
