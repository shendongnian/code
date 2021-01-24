                BlobContinuationToken blobContinuationToken = null;
                var results = await inputContainer.ListBlobsSegmentedAsync(null, blobContinuationToken);
                
                foreach (IListBlobItem item in results.Results)
                {
                    log.LogInformation(item.Uri.Segments.Last());
                }
