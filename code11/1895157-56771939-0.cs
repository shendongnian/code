    List<string> lstPath = DAL_AttachmentSQLHelper.GetAllAttachementPath(claimId);            
    CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
    var container = cloudStorageAccount.CreateCloudBlobClient().GetContainerReference("traveoappclaimattachments");           
    using (var zipOutputStream = new ZipOutputStream(System.Web.HttpContext.Current.Response.OutputStream))
    {
        foreach (var blobFileName in lstPath)
        {
            zipOutputStream.SetLevel(0);
            var blob = container.GetBlockBlobReference("Traveo1/" + blobFileName);
            var entry = new ZipEntry(blobFileName);
            zipOutputStream.PutNextEntry(entry);
            blob.DownloadToStream(zipOutputStream);
        }
        zipOutputStream.Finish();
        zipOutputStream.Close();
    }
    System.Web.HttpContext.Current.Response.BufferOutput = false;
    System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + "zipFileName.zip");
    System.Web.HttpContext.Current.Response.ContentType = "application/octet-stream";
    System.Web.HttpContext.Current.Response.Flush();
    System.Web.HttpContext.Current.Response.End();
