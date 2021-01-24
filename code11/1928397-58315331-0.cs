        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            //file is not locked
            return false;
        }
        private void Process(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (paths.Count > 0)
            {
                var currentPath = paths.Dequeue();
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(UserSettings.Instance.getConnectionString());
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = blobClient.GetContainerReference(UserSettings.Instance.getContainer());
                CloudBlockBlob b = blobContainer.GetBlockBlobReference(System.IO.Path.GetFileName(currentPath));
                try
                {
                    FileInfo fi = new FileInfo(currentPath);
                    while (IsFileLocked(fi))
                        Thread.Sleep(5000); // Wait 5 seconds before checking again
                    b.UploadFromFile(currentPath, FileMode.Open);
                }
                catch (StorageException s)
                {
                    throw new System.InvalidOperationException("Could not connect to the specified storage account. Please check the configuration.");
                }
                catch (IOException exc)
                {
                    throw new System.InvalidOperationException(exc.StackTrace);
                }
            }
        }
