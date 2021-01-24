            string[] fileSystemEntries = Directory.GetFileSystemEntries(path);
            var tasks = fileSystemEntries.OrderBy(s => s).Select(
            fileName => UploadFiles(year, month, Path.GetFileName(fileName), accesstoken, path));
            
            await Task.WhenAll(tasks);
            Dts.Events.FireInformation(0, "Script Task for uploading AVRO files", "All Files Uploaded", string.Empty, 0, ref fireAgain);
