                        //your other code
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            // add this line of code.
                            if (entry.FullName.EndsWith("/")) { continue; }
    
                            log.LogInformation($"Now processing {entry.FullName}");
    
                            CloudBlockBlob blockBlob = container.GetBlockBlobReference(entry.Name);
                            using (var fileStream = entry.Open())
                            {
                                await blockBlob.UploadFromStreamAsync(fileStream);
                            }
                        }
