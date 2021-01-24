    public async Task<byte[]> CreateZip(Guid ownerId)
            {
                try
                {
                    string startPath = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}_zipFolder");//folder to add
                    
                    Directory.CreateDirectory(startPath);
    
                    var attachemnts = await ReadByOwnerId(ownerId);
                    attachemnts.Data = filterDuplicateAttachments(attachemnts.Data);
                    //filtering youtube urls
                    attachemnts.Data = attachemnts.Data.Where(i => !i.Flags.Equals("YoutubeUrl", StringComparison.OrdinalIgnoreCase)).ToList();
    
                    attachemnts.Data.ForEach(i =>
                    {
                        var fileLocalPath = $"{startPath}\\{i.Category}";
                        if (!Directory.Exists(fileLocalPath))
                        {
                            Directory.CreateDirectory(fileLocalPath);
                        }
                        using (var client = new WebClient())
                        {
                            client.DownloadFile(i.Url, $"{fileLocalPath}//{i.Flags ?? ""}_{i.FileName}");
                        }
                    });
    
                    using (var ms = new MemoryStream())
                    {
                        using (var zipArchive = new ZipArchive(ms, ZipArchiveMode.Create, true))
                        {
                            System.IO.DirectoryInfo di = new DirectoryInfo(startPath);
                            var allFiles = di.GetFiles("",SearchOption.AllDirectories);
                            foreach (var attachment in allFiles)
                            {
                                var file = File.OpenRead(attachment.FullName);
    
                                var type = attachemnts.Data.Where(i => $"{ i.Flags ?? ""}_{ i.FileName}".Equals(attachment.Name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                                var entry = zipArchive.CreateEntry($"{type.Category}/{attachment.Name}", CompressionLevel.Fastest);
                                using (var entryStream = entry.Open())
                                {
                                    file.CopyTo(entryStream);
                                }
                            }
                        }
                        var result = ms.ToArray();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    var a = ex;
                    return null;
                }
            }
