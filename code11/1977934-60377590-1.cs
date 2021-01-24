     var queryDupFiles = fileDb.Table<FileProperty>()
                               .GroupBy(file =>
                                 new FileProperty {
                                   Name = file.Name,
                                   LastWriteTime = file.LastWriteTime,
                                   Length = file.Length
                                 })
                               .Where(g => g.Count() > 1);
