    using (ZipArchive archive = new ZipArchive(await response.Content.ReadAsStreamAsync())) {
        foreach (ZipArchiveEntry entry in archive.Entries) {
            using (Stream stream = entry.Open()) {                        
                string destination = Path.GetFullPath(Path.Combine(downloadPath, entry.FullName));
                var directory = Path.GetDirectoryName(destination);
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);
                using (FileStream file = new FileStream(destination, FileMode.Create, FileAccess.Write)) {
                    await stream.CopyToAsync(file);
                }
            }
        }
    }
