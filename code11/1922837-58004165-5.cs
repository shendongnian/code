    var joinBlock = new JoinDependencyBlock<FileInfo, FileInfo>((fi1, fi2) =>
    {
        // Check if the files are matched
        var name1 = Path.GetFileNameWithoutExtension(fi1.Name);
        var name2 = Path.GetFileNameWithoutExtension(fi2.Name);
        return StringComparer.OrdinalIgnoreCase.Equals(name1, name2);
    });
    var actionBlock = new ActionBlock<(FileInfo, FileInfo)>(pair =>
    {
        // Process the matching files
        Console.WriteLine(pair.Item1.Name + " :: " +  pair.Item2.Name);
    });
    joinBlock.LinkTo(actionBlock);
