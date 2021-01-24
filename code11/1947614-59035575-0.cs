cs
//newfile: HTTPPostedFileBase
Google.Apis.Drive.v3.Data.File deliverable = new Google.Apis.Drive.v3.Data.File();
deliverable.Parents = new List<string>();
deliverable.Name = newfile.FileName;
deliverable.Parents.Add(folderID);
FilesResource.CreateMediaUpload request = service.Files.Create(deliverable, newfile.InputStream, newfile.ContentType);
request.Upload();
