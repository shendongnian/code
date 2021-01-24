    //convert the excel package to a byte array
    byte[] bin = excelPackage.GetAsByteArray();
    
    //clear the buffer stream
    Response.ClearHeaders();
    Response.Clear();
    Response.Buffer = true;
    
    //set the correct contenttype
    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    
    //set the correct length of the data being send
    Response.AddHeader("content-length", bin.Length.ToString());
    
    //set the filename for the excel package
    Response.AddHeader("content-disposition", "attachment; filename=\"ExcelDemo.xlsx\"");
    
    //send the byte array to the browser
    Response.OutputStream.Write(bin, 0, bin.Length);
    
    //cleanup
    Response.Flush();
    HttpContext.Current.ApplicationInstance.CompleteRequest();
