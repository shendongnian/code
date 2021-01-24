        public static async Task UploadFileAsync(string fileName)
        {
            var file = new Google.Apis.Drive.v3.Data.File();
            file.Name = Path.GetFileName(fileName);
            file.Parents = new List<string> {folderID};
            byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
            using (System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray))
            {
                await service.Files.Create(file, stream, "some mime type").UploadAsync();
            }
        }
