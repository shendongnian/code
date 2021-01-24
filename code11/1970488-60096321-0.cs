                    using (var zipArchiveMemoryStream = await zipBlockBlob.OpenWriteAsync(null, bro, null))
                    using (var zipArchive = new ZipArchive(zipArchiveMemoryStream, ZipArchiveMode.Create))
                    {
                        foreach (FilesListModel FileName in filesList)
                        {
                            if (await container.ExistsAsync())
                            {
                                CloudBlob file = container.GetBlobReference(FileName.FileName);
                                if (await file.ExistsAsync())
                                {
                                    // zip: get stream and add zip entry
                                    var entry = zipArchive.CreateEntry(FileName.FileName, CompressionLevel.Fastest);
                                    // approach 1
                                    using (var entryStream = entry.Open())
                                    {
                                        await file.DownloadToStreamAsync(entryStream, null, bro, null);
                                        entryStream.Close();
                                    }
                                }
                            }
                        }
                        zipArchiveMemoryStream.Close();
}
