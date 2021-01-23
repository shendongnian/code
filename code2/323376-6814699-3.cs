            LinkButton btnTemp = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btnTemp.NamingContainer;
            HiddenFieldFullFileName.Value = row.Cells[1].Text;
            FileInfo file = new FileInfo(HiddenFieldFullFileName.Value);
            if (file.Exists)
            {
                 
                string lastUpdateTimeStamp = file.LastWriteTimeUtc.ToString("r");
                string _EncodedData = HttpUtility.UrlEncode(file.Name, Encoding.UTF8) + lastUpdateTimeStamp;
                //Clear the content of the response
                Response.Clear(); 
                Response.AppendHeader("ETag", "\"" + _EncodedData + "\"");
                Response.AppendHeader("Last-Modified", lastUpdateTimeStamp);
                //Set the ContentType
                Response.ContentType = "application/octet-stream"; 
                //Add the file name and attachment,
                //which will force the open/cancel/save dialog to show, to the header
                Response.AddHeader("Content-Disposition", "attachment;filename=" + file.Name); 
               
                //Send data
                Response.WriteFile(file.FullName);
                Response.End();
            }
