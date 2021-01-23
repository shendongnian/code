    string sName = "target.docx";
    string sBase64 = "THE GIANT BASE 64 DATA";        
    Response.AddHeader("Content-disposition", "attachment; filename=" + sName);
    Response.ContentType = "application/octet-stream";
    Response.BinaryWrite(System.Convert.FromBase64String(sBase64));
    Response.End();
