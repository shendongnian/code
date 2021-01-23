    //Function for File Download in ASP.Net in C# and 
    //Tracking the status of success/failure of Download.
    private bool DownloadableProduct_Tracking()
    {
    //File Path and File Name
    string filePath = Server.MapPath("~/ApplicationData/DownloadableProducts");
    string _DownloadableProductFileName = "DownloadableProduct_FileName.pdf";
    System.IO.FileInfo FileName = new System.IO.FileInfo(filePath + "\\" + _DownloadableProductFileName);
    FileStream myFile = new FileStream(filePath + "\\" + _DownloadableProductFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
    //Reads file as binary values
    BinaryReader _BinaryReader = new BinaryReader(myFile);
    //Ckeck whether user is eligible to download the file
    if (IsEligibleUser())
    {
	//Check whether file exists in specified location
	if (FileName.Exists)
	{
	    try
	    {
		long startBytes = 0;
		string lastUpdateTiemStamp = File.GetLastWriteTimeUtc(filePath).ToString("r");
		string _EncodedData = HttpUtility.UrlEncode(_DownloadableProductFileName, Encoding.UTF8) + lastUpdateTiemStamp;
		Response.Clear();
		Response.Buffer = false;
		Response.AddHeader("Accept-Ranges", "bytes");
		Response.AppendHeader("ETag", "\"" + _EncodedData + "\"");
		Response.AppendHeader("Last-Modified", lastUpdateTiemStamp);
		Response.ContentType = "application/octet-stream";
		Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName.Name);
		Response.AddHeader("Content-Length", (FileName.Length - startBytes).ToString());
		Response.AddHeader("Connection", "Keep-Alive");
		Response.ContentEncoding = Encoding.UTF8;
		//Send data
		_BinaryReader.BaseStream.Seek(startBytes, SeekOrigin.Begin);
		//Dividing the data in 1024 bytes package
		int maxCount = (int)Math.Ceiling((FileName.Length - startBytes + 0.0) / 1024);
		//Download in block of 1024 bytes
		int i;
		for (i = 0; i < maxCount && Response.IsClientConnected; i++)
		{
		    Response.BinaryWrite(_BinaryReader.ReadBytes(1024));
		    Response.Flush();
		}
		//if blocks transfered not equals total number of blocks
		if (i < maxCount)
		    return false;
		return true;
	    }
	    catch
	    {
		return false;
	    }
	    finally
	    {
		Response.End();
		_BinaryReader.Close();
		myFile.Close();
	    }
	}
	else System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(),
	    "FileNotFoundWarning","alert('File is not available now!')", true);
    }
    else
    {
	System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), 
	    "NotEligibleWarning", "alert('Sorry! File is not available for you')", true);
    }
    return false;
    }
