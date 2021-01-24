        public static async Task WriteToFile(string relativePath, string data)
        {
            StorageFile sampleFile = await localFolder.CreateFileAsync(relativePath,
                CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, data);
        }
        // Read data from a file
        public static async Task<string> ReadFromFile(string relativePath, string backupPath = "")
        {
            try
            {
                StorageFile sampleFile = await localFolder.GetFileAsync(relativePath);
                return await FileIO.ReadTextAsync(sampleFile);
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine( "Relative path: {0}, backupPath: {1}, Error str: {2}", relativePath, backupPath, e.Message);
                if (backupPath == "")
                    return "";
                else
                {
                    await CopyFile(backupPath, relativePath);
                    return await ReadFromFile(relativePath);
                }
            }
            catch (IOException e)
            {
                Debug.WriteLine(e.Message);
            }
            return "";
        }
        public static async Task CopyFile(string src, string relativeDst)
        {
            try
            {
                StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(
                    new Uri(src));
                await file.CopyAsync(localFolder, relativeDst, NameCollisionOption.ReplaceExisting);
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Debug.WriteLine(e.Message);
            }
        }
