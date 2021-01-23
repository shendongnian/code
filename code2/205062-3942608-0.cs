    private void LoadAttachment()
        {
                byte[] ImageData = ... get data from somewhere ...
                
                Response.Buffer = true;
                String filename = "itakethis.fromdatabase";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + filename);
                Response.ContentType = GetMimeType(filename);//you can try to extrapolate it from file extension
    			if(ImageData.Length > 0)
    				Response.BinaryWrite(ImageData);
    			else
    				Response.BinaryWrite(new byte[1]);
                Response.Flush();
                ApplicationInstance.CompleteRequest();
        }
`
