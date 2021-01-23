        public ActionResult GetFile(string file, string extension)
        {
            return GetFileInFolder("", file, extension);
        }
        public ActionResult GetFileInFolder(string subfolder, string file, string extension)
        {
            var path = Path.Combine(Server.MapPath("~/Content"), subfolder, file + "." + extension);
            if (!System.IO.File.Exists(path)) throw new HttpException(404, "File Not Found");
            var mimetype = mimeTypes.ContainsKey(extension) ? mimeTypes[extension] : "text/plain";
            return File(path, mimetype);
        }
