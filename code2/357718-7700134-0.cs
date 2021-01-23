    public byte[] uploadedFileToByteArray(HttpPostedFileBase file)
    {
       int nFileLen = file.ContentLength;
       int currentPosition = 0;
       byte[] result = new byte[nFileLen];
       Session["fileLen"] = nFileLen;
       int bytesRead = file.InputStream.Read(result,0,1000);
       while (bytesRead > 0)
       {
          currentPosition += bytesRead;
          Session["progress"] = currentPosition;
          bytesRead = file.InputStream.Read(result,currentPosition,1000);
       }
       return result;
    }
    public ActionResult ReportProgress()
    {
         int nFileLen = (int)Session["fileLen"];
         int progress = (int)Session["progress"];
         return Json( new { Progress = (float)progress/nFileLen, Complete = nFileLen >= progress } );
    }
