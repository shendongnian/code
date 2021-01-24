    public async Task<List<EvaluationImage>> GetImagesFromVirtualFolder(CloudBlobContainer blobContainer, string customer)
        {
            var images = new List<EvaluationImage>();
            BlobContinuationToken blobContinuationToken = null;
            do
            {
               //this is the overload to use, you pass in the full virtual path from the main container to where the files are (prefix), use a
              //useflatbloblisting (true value in 2nd parameter), BlobListingDetail, I chose 100 as the max number of blobs (parameter 4) 
              //then the token and the last two parameters can be null       
                var results = await blobContainer.
                    ListBlobsSegmentedAsync("publicfiles/images/" + customer,true,BlobListingDetails.All, 100, blobContinuationToken,null,null);
                // Get the value of the continuation token returned by the listing call.
                blobContinuationToken = results.ContinuationToken;
                foreach (var item in results.Results)
                {
                    var filename = GetFileNameFromBlobUri(item.Uri, customer);
                    var img = new EvaluationImage
                    {
                        ImageUrl = item.Uri.ToString(),
                        ImageCaption = GetCaptionFromFilename(filename),
                        IsPosterImage = filename.Contains("poster")
                    };
                    images.Add(img);
                }
            } while (blobContinuationToken != null);
           
            return images;
        }
