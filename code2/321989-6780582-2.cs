            rptCS.Close();
            rptCS.Dispose();
            rptAd.Close();
            rptAd.Dispose();
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", 
        "attachment; filename=" + 
        "Application of " + FullName.Trim() + ".pdf");
            Response.BinaryWrite(ms.ToArray());
            ApplicationInstance.CompleteRequest();
