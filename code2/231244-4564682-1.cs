    var groupedFiles = files.Aggregate(
        new List<List<FileInfo>>(),
        (groups, file) => {
            List<FileInfo> group = groups.FirstOrDefault(
               g => g.Sum(f => f.Length) + file.Length <= 1024 * 1024 * 5
            );
            if (group == null) {
                group = new List<FileInfo>();
                groups.Add(group);
            }
            group.Add(file);
            return groups;
        }
    );
