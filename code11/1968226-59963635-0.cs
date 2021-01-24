        private static async Task<File> CreateRankingsFolder(DriveService service, 
            string driveId, 
            string parentId, 
            string folderName = "YOURFOLDERNAME")
        {
            File result = null;
            try
            {
                File body = new File();
                body.Name = folderName;
                body.MimeType = "application/vnd.google-apps.folder";
                body.DriveId = driveId;
                if (!string.IsNullOrEmpty(parentId))
                {
                    var _parents = new List<string>()
                    {
                        parentId
                    };
                    body.Parents = _parents;
                }
                // service is an authorized Drive API service instance
                var req = service.Files.Create(body);
                
                result = await req.ExecuteAsync();
            }
            catch(Exception e)
            {
            }
            return result;
        }
