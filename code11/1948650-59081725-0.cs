                string folderName = "Upload/Profile/" + user.Id;
                string webRootPath = _hostingEnvironment.ContentRootPath;
                string newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }
                string extention = file.ContentType.Split("/")[1];
                string fileName = user.Id + ".jpg";
                string fullPath = Path.Combine(newPath, fileName);
                string envpath = folderName + "/" + fileName;
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
