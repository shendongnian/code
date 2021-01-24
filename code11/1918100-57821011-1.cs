    public string AddFile(string path, string contentType, string driveId)
    {
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            Google.Apis.Drive.v3.Data.File fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = Path.GetFileName(path),
                DriveId = driveId
            };
            var request = _service.Files.Create(fileMetadata, stream, contentType);
            request.Fields = "id";
            request.SupportsTeamDrives = true;
            IUploadProgress requestResult = request.Upload();
            if (requestResult.Exception != null) throw requestResult.Exception;
            Google.Apis.Drive.v3.Data.File file = request.ResponseBody;
            return file == null ? "" : file.Id;
        }
    }
