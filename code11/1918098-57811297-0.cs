    public string AddFile(string path, string contentType, string driveId)
        {
            FilesResource.CreateMediaUpload request;
            using (FileStream stream = new FileStream(path,
                FileMode.Open))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    File fileMetadata = new Google.Apis.Drive.v3.Data.File
                    {
                        Name = Path.GetFileName(path),
                        DriveId = driveId
                    };
                    request = _service.Files.Create(
                        fileMetadata, memoryStream, contentType);
                    request.Fields = "id";
                    request.SupportsTeamDrives = true;
                    request.Upload();
                }
            }
            File file = request.ResponseBody;
            return file.Id;
        }
