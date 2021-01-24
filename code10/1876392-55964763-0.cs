     if (file != null)
            {
                if (file != null && file.ContentLength > 0)
                {
                    string dirUrl = "~/Uploads/";
                    string dirPath = Server.MapPath(dirUrl);
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }
                    string fileUrl = dirUrl + "/" + Path.GetFileName(file.FileName);
                    file.SaveAs(Server.MapPath(fileUrl));
                }
            }
