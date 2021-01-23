        private async Task GetLocalImageAsync(string internetUri, string folderName, string uniqueName)
        {
            using (var response = await HttpWebRequest.CreateHttp(internetUri).GetResponseAsync())
            {
                using (var stream = response.GetResponseStream())
                {
                    var folder = await ApplicationData.Current.LocalFolder
                                    .CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
                    StorageFile file = await folder.CreateFileAsync(string.Format("{0}", uniqueName), CreationCollisionOption.ReplaceExisting);
                    using (var filestream = await file.OpenStreamForWriteAsync())
                    {
                        await stream.CopyToAsync(filestream);
                        await filestream.FlushAsync();
                    }
                }
            }
        }
