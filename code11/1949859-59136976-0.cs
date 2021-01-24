    var convList = entries.Select(x => new FilesDetailsDto()
                {
                    FullPath = x,
                    LastModifiedOnFilesystem = System.IO.File.GetLastWriteTime(x)
                });
