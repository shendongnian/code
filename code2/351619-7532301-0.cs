    string physicalFilename = Server.MapPath("~/") + filename;
    FileUploadControl1.SaveAs(physicalFilename);
    DataTable dt = new DataTable(); 
    dt.ReadXml(physicalFileName);
    // use SlkBulkCopy to import the dt
