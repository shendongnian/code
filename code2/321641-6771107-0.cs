            [WebMethod]
        public bool Import(int libraryID, string folderName, string fileName, byte[] bytes)
        {
            SiteInfo siteInfo = SiteInfoProvider.GetCurrentSite();
            MediaLibraryInfo libraryInfo = MediaLibraryInfoProvider.GetMediaLibraryInfo(libraryID);
            fileName = fileName.Replace(" ", "-").Replace("&", "-").Replace("'", "-").Replace("+", "-").Replace("=", "-").Replace("[", "-").Replace("]", "-").Replace("#", "-").Replace("%", "-").Replace("\\", "-").Replace("/", "-").Replace(":", "-").Replace("*", "-").Replace("?", "-").Replace("\"", "-").Replace("<", "-").Replace(">", "-").Replace("|", "-");
            bool bRetValue = false;
            string filePath = Server.MapPath(string.Format("/{0}/media/{1}/{2}/{3}", siteInfo.SiteName, libraryInfo.LibraryFolder, folderName, fileName));
            File.WriteAllBytes(filePath, bytes);
            if (File.Exists(filePath))
            {
                string path = MediaLibraryHelper.EnsurePath(filePath);
                MediaFileInfo fileInfo = new MediaFileInfo(filePath, libraryInfo.LibraryID, folderName);
                fileInfo.FileSiteID = siteInfo.SiteID;
                MediaFileInfoProvider.ImportMediaFileInfo(fileInfo);
                bRetValue = true;
            }
            return bRetValue;
        }
                string filePath = "~/SITENAME/media/SITE_MEDIALIB/Logos/";
            string fileName = string.Empty  ;
            
            if (fileLogo.FileName.Length > 0)
            {
                var ext = fileLogo.FileName.Substring(fileLogo.FileName.LastIndexOf('.') + 1).ToLower();
                fileName = entryTitle + "." + ext; 
                MediaLibrary il = new MediaLibrary();
                il.Import(3, "FOLDERNAME", fileName, fileLogo.FileBytes);
            }
