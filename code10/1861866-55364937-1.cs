public async Task<ActionResult> Test()
{
     Response.Buffer = true;
     Response.Clear();
     Response.ContentType = "application/pdf";
     await BlobStorageUtils.DownloadFile(Response.OutputStream);
     return new EmptyResult();
}
Code to retrieve file from Blob Container
public static async Task DownloadFile(Stream outputStream)
{
    CloudBlockBlob cloudBlockBlob = 
                                CloudBlobContainer.GetBlockBlobReference("document.pdf");
    await cloudBlockBlob.DownloadToStreamAsync(outputStream);
}
