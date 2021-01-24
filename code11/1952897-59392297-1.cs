            var listFiles = ListAllFiles(service).Files;
            if (listFiles != null && listFiles.Count > 0)
            {
                foreach (var file in listFiles)
                {
                    if (file.Id == aIdFolder && !String.IsNullOrWhiteSpace(file.TeamDriveId))
                    {
                         //here your result
                        return true;
                        
                    }
                }
            }
