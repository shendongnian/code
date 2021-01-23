       public class ContentController : Controller
        {
            public ActionResult LoadContent(string dir, string file)
            {
                string fileName = Server.MapPath(Url.Content("~/Content/" + dir)) 
                fileName += "\\" + file;            
    
                // stream file if exists    
                FileInfo info = new FileInfo(fileName);
                if (info.Exists)
                    return File(info.OpenRead(), MimeType(fileName));
    
                
                // else return null - file not found
                return null;            
            }
    
    
            private string MimeType(string filename)
            {
                string mime = "application/octetstream";
                var extension = Path.GetExtension(filename);
                if (extension != null)
                {
                   RegistryKey rk = Registry.ClassesRoot.OpenSubKey(extension.ToLower());
                    if (rk != null && rk.GetValue("Content Type") != null)
                        mime = rk.GetValue("Content Type").ToString();
                }
    
                return mime;
            }
        }
}
