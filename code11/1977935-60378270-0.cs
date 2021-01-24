    IEnumerable<FileProperty> queryDupFiles =
       (from file in fileDb.FileProperties
       group file.FullName by
           new { file.Name, file.LastWriteTime, file.Length}
           into fileGroup
       where fileGroup.Count() > 1
       select fileGroup).AsEnumerable()
                        .Select(g => new FileProperty { 
                            Name = g.Key.Name, 
                            LastWriteTime = g.Key.LastWriteTime, 
                            Length = g.Key.Length, 
                            FullName = g.First() });
