    class Program
        {
            static void Main(string[] args)
            {
    
                var service = Oauth2Example.GetDriveService(@"C:\Users\linda\Documents\.credentials\NativeClient.json", "test",
                    new[] {Google.Apis.Drive.v3.DriveService.Scope.Drive});
    
                var fileMetadata = new Google.Apis.Drive.v3.Data.File()
                {
                    Name = "flag.jpg"
                };
    
                FilesResource.CreateMediaUpload request;
                using (var stream = new System.IO.FileStream(@"C:\temp\flag.jpg", System.IO.FileMode.Open))
                {
                    request = service.Files.Create(fileMetadata, stream, "image/jpeg");
                    request.Fields = "id";
                    request.Upload();
                }
    
                var file = request.ResponseBody;
                Console.WriteLine("File ID: " + file.Id);
                Console.ReadKey();
            }
        }
