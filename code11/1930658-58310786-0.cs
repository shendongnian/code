    if (File.GetLastWriteTime(file) > DateTime.Today)
    {
        var fileNameOnly = Path.GetFileNameWithoutExtension(file);
        var ext = Path.GetExtension(file);
        var dest = Path.Combine(archive, fileNameOnly + ext);
        var pattern = fileNameOnly + "*" + ext;
        var lastCopy = Directory.EnumerateFiles(archive, pattern, System.IO.SearchOption.TopDirectoryOnly)
            .OrderBy(x => x.Length)
            .ToList()
            .LastOrDefault();
        var newName = fileNameOnly + ext;
        if (lastCopy != null)
        {
            var lastCopyNameOnly = Path.GetFileNameWithoutExtension(lastCopy);
            var match = Regex.Match(lastCopyNameOnly, @"(.+)\((\d+)\)");
            var lastNum = 1;
            if (match.Success)
            {
                int.TryParse(match.Groups[2].Value, out lastNum);
                lastNum++;
            }
            newName = string.Format("{0}({1}){2}", fileNameOnly, lastNum, ext);
        }
        dest = Path.Combine(archive, newName);
        File.Copy(file, dest);
    }
