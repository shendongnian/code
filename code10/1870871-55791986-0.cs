    public async Task<IEnumerable<PhotoViewModel>> Add(HttpRequestMessage request) 
    { 
        CloudBlobClient blobClient = this.StorageAccount.CreateCloudBlobClient(); 
        CloudBlobContainer photoContainer = blobClient.GetContainerReference(this.ContainerName); 
     
        var provider = new AzureBlobMultipartFormDataStreamProvider(photoContainer); 
     
        await request.Content.ReadAsMultipartAsync(provider); 
     
        var photos = new List<PhotoViewModel>(); 
     
        foreach (var file in provider.FileData) 
        { 
            //the LocalFileName is going to be the absolute Uri of the blob (see GetStream) 
            //use it to get the blob info to return to the client 
            var blob = await photoContainer.GetBlobReferenceFromServerAsync(file.LocalFileName); 
            await blob.FetchAttributesAsync(); 
     
            photos.Add(new PhotoViewModel 
            { 
                Name = blob.Name, 
                Size = blob.Properties.Length / 1024, 
                Created = blob.Metadata["Created"] == null ? DateTime.Now : DateTime.Parse(blob.Metadata["Created"]), 
                Modified = ((DateTimeOffset)blob.Properties.LastModified).DateTime, 
                Url = blob.Uri.AbsoluteUri 
            }); 
        } 
     
        return photos;       
    }
