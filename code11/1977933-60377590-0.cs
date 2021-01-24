     var queryDupFiles = fileDb.Table<FileProperty>()
                               .GroupBy(p =>
                                 new FileProperty {
                                   Name = file.Name,
                                   LastWriteTime = file.LastWriteTime,
                                   Length = file.Length
                                 })
                               .Where(g => g.Count() > 1);
