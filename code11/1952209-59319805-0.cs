    public async Task<DriveItem> UploadSmallFile(IFormFile file, bool uploadToSharePoint)
        {
            IFormFile fileToUpload = file;
            Stream ms = new MemoryStream();
            
            using (ms = new MemoryStream()) //this keeps the stream open
            {
                await fileToUpload.CopyToAsync(ms);
                ms.Seek(0, SeekOrigin.Begin);
                var buf2 = new byte[ms.Length];
                ms.Read(buf2, 0, buf2.Length);
                
                ms.Position = 0; // Very important!! to set the position at the beginning of the stream
                GraphServiceClient _graphServiceClient = await AuthenticateViaAppIdAndSecret();
                
                DriveItem uploadedFile = null;
                if (uploadToSharePoint == true)
                {
                    uploadedFile = (_graphServiceClient
                    .Sites["root"]
                    .Drives["{DriveId}"]
                    .Items["{Id_of_Targetfolder}"]
                    .ItemWithPath(fileToUpload.FileName)
                    .Content.Request()
                    .PutAsync<DriveItem>(ms)).Result;
                }
                else
                {
                    // Upload to OneDrive (for Business)
                    uploadedFile = await _graphServiceClient
                    .Users["{Your_EmailAdress}"]
                    .Drive
                    .Root
                    .ItemWithPath(fileToUpload.FileName)
                    .Content.Request()
                    .PutAsync<DriveItem>(ms);
                }
                ms.Dispose(); //clears memory
                return uploadedFile; //returns a DriveItem. 
            }
        }
