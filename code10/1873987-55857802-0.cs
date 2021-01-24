    foreach (string file in fileNames)
    {
        // Build the destination path
        var destination = Path.Combine(
            dialog.SelectedPath,                        // The root destination folder
            Path.GetExtension(file).Replace(".", ""),   // The file extension folder
            Path.GetFileName(file));                    // The file name (including extension)
        // Move the file
        File.Move(file, destination);
    }
-----
