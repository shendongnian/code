    public class PublicController : Controller
    {
        private IDictionary<String, String> mimeTypes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                                                            {{"css", "text/css"}, {"jpg", "image/jpg"}};
        public ActionResult GetFile(string file)
        {
            var path = Path.Combine(Server.MapPath("~/Content"), file);
        
            if (!System.IO.File.Exists(path)) throw new HttpException(404, "File Not Found");
            var extension = GetExtension(file); // psuedocode
            var mimetype = mimeTypes.ContainsKey(extension) ? mimeTypes[extension] : "text/plain";
            return File(path, mimetype);
        }
    }
