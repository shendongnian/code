    using (var getObjectResponse = await _s3Client.GetObjectAsync(request))
    using (MemoryStream ms = new MemoryStream())
    {
        getObjectResponse.ResponseStream.CopyTo(ms);
        FileContentResult download = new FileContentResult(ms.ToArray(), "application/pdf");
        return download.FileContents;
    }
     
                
