        public async void GetDrive()
        {
            StorageFolder externalDevices = KnownFolders.RemovableDevices;
            IReadOnlyList<StorageFolder> externalDrives = await externalDevices.GetFoldersAsync();
            StorageFolder x = externalDrives[0];
            IReadOnlyList<StorageFile> items = await x.GetFilesAsync();
            foreach (StorageFile file in items)
            {
                try
                {
                    mediaPlayer.Source = MediaSource.CreateFromStorageFile(file);
                }
                catch (Exception ex)
                {
                }
            }
        }
