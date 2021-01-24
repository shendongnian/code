        public FileResult DownloadFile(string file)
        {
           string path = Server.MapPath(String.Format("~/pdf/{0}", file));
           if (System.IO.File.Exists(path))
           {
              string mime = MimeMapping.GetMimeMapping(path);
              return File(path, mime);
           }
        }
