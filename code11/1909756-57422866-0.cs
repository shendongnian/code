        public async Task<RevisionInfo> DownloadAsync(int revision)
        {
            var url = GetDownloadURL(Platform, DownloadHost, revision);
            var zipPath = Path.Combine(DownloadsFolder, $"download-{Platform.ToString()}-{revision}.zip");
            var folderPath = GetFolderPath(revision);
    
            if (new DirectoryInfo(folderPath).Exists)
            {
                return RevisionInfo(revision);
            }
    
            var downloadFolder = new DirectoryInfo(DownloadsFolder);
            if (!downloadFolder.Exists)
            {
                downloadFolder.Create();
            }
    
            if (DownloadProgressChanged != null)
            {
                _webClient.DownloadProgressChanged += DownloadProgressChanged;
            }
            await _webClient.DownloadFileTaskAsync(new Uri(url), zipPath).ConfigureAwait(false);
    
            if (Platform == Platform.MacOS)
            {
                //ZipFile and many others unzip libraries have issues extracting .app files
                //Until we have a clear solution we'll call the native unzip tool
                //https://github.com/dotnet/corefx/issues/15516
                NativeExtractToDirectory(zipPath, folderPath);
            }
            else
            {
                ZipFile.ExtractToDirectory(zipPath, folderPath);
            }
    
            new FileInfo(zipPath).Delete();
    
            var revisionInfo = RevisionInfo(revision);
    
            if (revisionInfo != null && GetCurrentPlatform() == Platform.Linux)
            {
                LinuxSysCall.Chmod(revisionInfo.ExecutablePath, LinuxSysCall.ExecutableFilePermissions);
            }
            return revisionInfo;
        }
