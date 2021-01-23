        public ActionResult GetFile(string file, string extension)
        {
            var path = Path.Combine(Server.MapPath("~/Content"), file + "." + extension);
        
            if (!System.IO.File.Exists(path)) throw new HttpException(404, "File Not Found");
            var mimetype = mimeTypes.ContainsKey(extension) ? mimeTypes[extension] : "text/plain";
            return File(path, mimetype);
        }
