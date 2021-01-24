        var sasToken = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
        {
            Permissions = SharedAccessBlobPermissions.Read,
            SharedAccessExpiryTime = DateTime.UtcNow.AddHours(1)//Assuming you want the link to expire after 1 hour
        });
        var blobUrl = string.Format("{0}{1}", blob.Uri.AbsoluteUri, sasToken);
        var response = Request.CreateResponse(HttpStatusCode.Moved);
        response.Headers.Location = new Uri(bloburl);
       
