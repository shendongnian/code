     Response.ContentType = "Application/pdf"; 
     Response.AppendHeader("Content-Disposition", "attachment; filename=Test_PDF.pdf"); 
     Response.TransmitFile(Server.MapPath("~/Files/Test_PDF.pdf")); 
     Response.End();
 
