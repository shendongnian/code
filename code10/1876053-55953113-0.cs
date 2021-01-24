        public static string CreateFolder(string folderName)
        {
            bool exists = Exists(folderName);
            if (exists)
                return $"Sorry but the file {folderName} already exists!";
            var file = new Google.Apis.Drive.v3.Data.File();
            file.Name = folderName;
            file.MimeType = "application/vnd.google-apps.folder";
            var request = service.Files.Create(file);
            request.Fields = "id";
            var result = request.Execute();
            return result.Id;
        }
        private static bool Exists(string name)
        {
            var listRequest = service.Files.List();
            listRequest.PageSize = 100;
            listRequest.Q = $"trashed = false and name contains '{name}' and 'root' in parents";
            listRequest.Fields = "files(name)";
            var files = listRequest.Execute().Files;
            foreach (var file in files)
            {
                if (name == file.Name)
                    return true;
            }
            return false;
        }
