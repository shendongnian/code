    private static void CustomRename(string directoryPath)
    {
        foreach (var file in Directory.GetFiles(directoryPath))
        {
            var basePath = Path.GetDirectoryName(file);
            var ext = Path.GetExtension(file);
            // If it doesn't have our extension, continue
            if (!ext.Equals(".pdf", StringComparison.OrdinalIgnoreCase)) continue;
                
            var nameParts = Path.GetFileNameWithoutExtension(file).Split('_');
            // If it doesn't have our required parts, continue
            if (nameParts.Length != 2) continue;
            var numericPart = nameParts[0];
            int number;
            // If the numeric part isn't numeric, continue
            if (!int.TryParse(numericPart, out number)) continue;
            // Create new file name and rename file by moving it
            var newName = $"{nameParts[1]}_f{number:0000}{ext}";
            File.Move(file, Path.Combine(basePath, newName));
        }
    }
