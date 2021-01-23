        string sj = "<script>" +
            " alert('" + msg + "')" +
            " </script>";       
        System.Web.UI.Page pg = (System.Web.UI.Page)objPage;
        pg.ClientScript.RegisterStartupScript(objPage.GetType(), "onload", sj);
    }
