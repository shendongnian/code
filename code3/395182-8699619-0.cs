        string attachment = "attachment; filename=OutputPeoplesoft.csv";
        HttpContext.Current.Response.AppendHeader("content-disposition", attachment);
        HttpContext.Current.Response.ContentType = "text/csv";
        HttpContext.Current.Response.AppendHeader("Pragma", "public");
        Response.WriteFile(strFilename);
        HttpContext.Current.Response.End();
