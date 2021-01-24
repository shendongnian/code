            //the code to get the blob again after uploading.
            var blockblob = blobContainer.GetBlockBlobReference(blobname);
            
            //the code to set medadata.
            blockblob.FetchAttributes();
            blockblob.Metadata["media"] = "www.bing.com";
            blockblob.SetMetadata();
